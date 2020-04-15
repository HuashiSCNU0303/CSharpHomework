using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler_WinForm
{
    class SimpleCrawler
    {
        public event Action sendSuccessEvent, sendFailureEvent, sendCrawlEndEvent;
        public event Action<string> sendCurrentUrlEvent;
        private Dictionary<string, bool> urlVisited;
        private Queue<string> urls;
        private string baseUrl;
        private int count = 0;
        public List<string> successUrls, failureUrls;
        private Thread crawlThread;

        public SimpleCrawler()
        {
            urls = new Queue<string>();
            successUrls = new List<string>();
            failureUrls = new List<string>();
            urlVisited = new Dictionary<string, bool>();
        }

        public void startCrawl(string startUrl)
        {
            stopCrawl();
            count = 0;
            successUrls.Clear();
            failureUrls.Clear();

            urls.Clear();
            urls.Enqueue(startUrl);
            
            urlVisited.Clear();
            urlVisited[startUrl] = true;
            
            crawlThread = new Thread(Crawl);
            crawlThread.IsBackground = true;
            crawlThread.Start();
        }

        public void stopCrawl()
        {
            if (crawlThread != null)
            {
                crawlThread.Suspend();
                sendCurrentUrlEvent("");
                crawlThread = null;
            }
        }

        private void Crawl()
        {
            while (true)
            {
                if (urls.Count == 0) 
                {
                    sendCrawlEndEvent();
                    break;
                }
                string current = urls.Dequeue();
                
                string html = DownLoad(current); // 下载
                if (html == "") 
                {
                    continue;
                }
                // count++;       
                Parse(html);//解析,并加入新的链接
                successUrls.Add(current);
                sendSuccessEvent();
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                sendCurrentUrlEvent(url);
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                baseUrl = url;
                return html;
            }
            catch (Exception ex)
            {
                failureUrls.Add(url);
                sendFailureEvent();
                return "";
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>', '\'');
                if (strRef.Length == 0 || strRef == "javascript:void(0);") continue;
                string url_transformed = null;
                if (strRef.Contains("http://") || strRef.Contains("https://"))
                {
                    url_transformed = strRef;
                }
                else
                {
                    if (strRef.Contains(".html") || strRef.Contains(".aspx"))
                    {
                        url_transformed = Transform(strRef, baseUrl);
                    }
                }

                if (url_transformed != null && !urlVisited.ContainsKey(url_transformed)) 
                {
                    urls.Enqueue(url_transformed);
                    urlVisited[url_transformed] = true;
                }
            }

        }

        private string Transform(string urlX, string objurl)
        {
            Uri baseUri = new Uri(objurl);
            Uri absoluteUri = new Uri(baseUri, urlX);
            return absoluteUri.ToString();
        }
    }
}

