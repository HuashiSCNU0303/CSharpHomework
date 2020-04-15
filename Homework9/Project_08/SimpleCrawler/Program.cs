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

namespace SimpleCrawler
{
    class SimpleCrawler
    {
        private Dictionary<string, bool> urlVisited = new Dictionary<string, bool>();
        private Queue<string> urls = new Queue<string>();
        private string baseUrl;
        private int count = 0;
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Enqueue(startUrl);
            myCrawler.urlVisited[startUrl] = true;
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                if (urls.Count == 0 || count > 20)
                {
                    break;
                }
                string current = urls.Dequeue();
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                count++;
                Parse(html);//解析,并加入新的链接
                Console.WriteLine("爬行结束");
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
                File.WriteAllText(fileName, html, Encoding.UTF8);
                baseUrl = url;
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                          .Trim('"', '\"', '#', '>','\'');
                if (strRef.Length == 0||strRef == "javascript:void(0);") continue;

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

