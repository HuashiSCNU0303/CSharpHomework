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
        SimpleCrawler myCrawler = new SimpleCrawler();
        public Form1()
        {
            InitializeComponent();
            simpleCrawlerBindingSource.DataSource = new BindingList<string>(myCrawler.successUrls);
            simpleCrawlerBindingSource1.DataSource = new BindingList<string>(myCrawler.failureUrls);
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            myCrawler.sendSuccessEvent += updateSuccessList;
            myCrawler.sendFailureEvent += updateFailureList;
            myCrawler.sendCrawlEndEvent += endCrawl;
            myCrawler.sendCurrentUrlEvent += updateCurrentUrl;
            myCrawler.startCrawl(txtStartSite.Text);
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
                lbxSuccessList.SelectedIndex = lbxSuccessList.Items.Count - 1;
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
                lbxFailureList.SelectedIndex = lbxFailureList.Items.Count - 1;
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
            // myCrawler.stopCrawl();
            MessageBox.Show("改为多线程后暂时无法停止，请等待本次爬虫完成！");
        }
    }
}
