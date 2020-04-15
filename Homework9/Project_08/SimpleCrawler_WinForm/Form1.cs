using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrawler_WinForm
{
    public partial class Form1 : Form
    {
        SimpleCrawler myCrawler;
        public Form1()
        {
            myCrawler = new SimpleCrawler();
            InitializeComponent();
            simpleCrawlerBindingSource.DataSource = new BindingList<string>(myCrawler.successUrls);
            simpleCrawlerBindingSource1.DataSource = new BindingList<string>(myCrawler.failureUrls);
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            myCrawler.startCrawl(txtStartSite.Text);
            myCrawler.sendSuccessEvent += updateSuccessList;
            myCrawler.sendFailureEvent += updateFailureList;
            myCrawler.sendCrawlEndEvent += endCrawl;
            myCrawler.sendCurrentUrlEvent += updateCurrentUrl;
        }

        private void updateSuccessList()
        {
            if (lbxSuccessList.InvokeRequired)
            {
                Action sendInfo = new Action(updateSuccessList);
                lbxSuccessList.Invoke(sendInfo, new object[] {});
            }
            else
            {
                simpleCrawlerBindingSource.DataSource = new BindingList<string>(myCrawler.successUrls);
            }
        }
        private void updateFailureList()
        {
            if (lbxFailureList.InvokeRequired)
            {
                Action sendInfo = new Action(updateFailureList);
                lbxFailureList.Invoke(sendInfo, new object[] {});
            }
            else
            {
                simpleCrawlerBindingSource1.DataSource = new BindingList<string>(myCrawler.failureUrls);
            }
        }
        private void endCrawl()
        {
            MessageBox.Show("爬虫已结束！");
        }
        private void updateCurrentUrl(string url)
        {
            if (lblCurrentSite.InvokeRequired)
            {
                Action<string> sendInfo = new Action<string>(updateCurrentUrl);
                lblCurrentSite.Invoke(sendInfo, new object[] { url });
            }
            else
            { 
                lblCurrentSite.Text = url;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            myCrawler.stopCrawl();
        }
    }
}
