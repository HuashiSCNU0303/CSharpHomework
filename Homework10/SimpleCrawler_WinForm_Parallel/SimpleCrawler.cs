using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SimpleCrawler_WinForm
{
    class SimpleCrawler
    {
        public event Action sendSuccessEvent, sendFailureEvent, sendCrawlEndEvent;
        public event Action<string> sendCurrentUrlEvent;
        private ConcurrentDictionary<string, bool> urlVisited;
        private ConcurrentQueue<string> urls;
        public List<string> successUrls, failureUrls;
        private List<Task> tasks;
        private int count = 0;
        private int currentTasks;
        private int maxTaskNum { get; set; }
        private int maxPageNum { get; set; }
        public SimpleCrawler()
        {
            urls = new ConcurrentQueue<string>();
            successUrls = new List<string>();
            failureUrls = new List<string>();
            urlVisited = new ConcurrentDictionary<string, bool>();
            maxTaskNum = 5;
            maxPageNum = 30;
        }

        public void startCrawl(string startUrl)
        {
            urls = new ConcurrentQueue<string>();
            count = 0;
            successUrls.Clear();
            sendSuccessEvent();
            failureUrls.Clear();
            sendFailureEvent();

            urls.Enqueue(startUrl);
            
            urlVisited.Clear();
            urlVisited[startUrl] = true;
            
            tasks = new List<Task>();
            Task t1 = Task.Factory.StartNew(Crawl);
            tasks.Add(t1);
            currentTasks = 1;
        }
        private void nextStart()
        {
            lock (this)
            {
                if (tasks.Count < maxTaskNum && urls.Count > maxTaskNum - tasks.Count)
                {
                    var t2 = Task.Factory.StartNew(Crawl);
                    tasks.Add(t2);
                    currentTasks++;
                }
            }
        }

        private void Crawl()
        {
            while (true)
            {
                lock (this)
                {
                    if (count >= maxPageNum || urls.Count == 0) 
                    {
                        if (currentTasks == 1) 
                        {
                            sendCrawlEndEvent();
                        }
                        currentTasks--;
                        break;
                    }
                }
                string current;
                urls.TryDequeue(out current);
                sendCurrentUrlEvent(current);
                string html = DownLoad(current); // 下载
                
                if (html == "") 
                {
                    continue;
                }
                Parse(html, current);//解析,并加入新的链接
                successUrls.Add(current);
                sendSuccessEvent();
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                count++;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                failureUrls.Add(url);
                sendFailureEvent();
                return "";
            }
        }

        private void Parse(string html, string url)
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
                        url_transformed = Transform(strRef, url);
                    }
                }

                if (url_transformed != null && !urlVisited.ContainsKey(url_transformed)) 
                {
                    urls.Enqueue(url_transformed);
                    nextStart();
                    urlVisited.TryAdd(url_transformed, true);
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

