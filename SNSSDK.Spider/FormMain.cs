using SNSSDK.Spider.Dal;
using SNSSDK.Spider.Hander;
using SNSSDK.Spider.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNSSDK.Spider
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
            if (this.timer1.Enabled)
            {
                this.btn_start.Text = "停止";
            }
            else
            {
                this.btn_start.Text = "开始";
            }
        }
        private delegate void DelegateSetDataGridView(List<MediaBase> list);
        private void BindDataGridView(List<MediaBase> list)
        {
            if (this.dataGridView1.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    dataGridView1.DataSource = list;
                }));
            }
            else
            {
                dataGridView1.DataSource = list;
            }
        }

        private delegate void DelegateSetStatus(string msg);
        private void SetStatus(string msg)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    tsslabel_status.Text = msg;
                }));
            }
            else
            {
                tsslabel_status.Text = msg;
            }
        }

        private void AppendConsole(string msg)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    this.tb_console.AppendText(msg+"\n\r");
                    this.tb_console.SelectionStart = this.tb_console.TextLength;
                    this.tb_console.ScrollToCaret();
                }));
            }
            else
            {
                this.tb_console.AppendText(msg + "\n\r");
                this.tb_console.SelectionStart = this.tb_console.TextLength;
                this.tb_console.ScrollToCaret();
            }
        }

        static MediaDal dal = new MediaDal();
        private async void GetLatestSnsTask(DelegateSetDataGridView  gridHander,DelegateSetStatus msgHander,DelegateSetStatus consoleHander)
        {
            Task t = new Task(delegate()
            {
                ListSpiderHander spiderHander = new ListSpiderHander();
                spiderHander.UserAgent = this.tb_useragent.Text;
                spiderHander.RequestProxy = new System.Net.WebProxy("127.0.0.1", 8888);

                ListRoot listRoot = spiderHander.CallUrl<ListRoot>(this.tb_url.Text.Replace("{category}", this.Category), "");
                List<MediaBase> mediaList = new List<MediaBase>();

                if (listRoot != null && listRoot.data != null && listRoot.data.Length > 0)
                {
                    foreach (var item in listRoot.data)
                    {
                        try
                        {
                            MediaBase media = Newtonsoft.Json.JsonConvert.DeserializeObject<MediaBase>(item.content);
                            mediaList.Add(media);
                            dal.Add(media);
                            consoleHander(string.Format("文章：{0}\r阅读数：{1}，媒体：{2}", media.title, media.read_count, media.source));
                        }
                        catch(Exception ex)
                        {
                            //ignore
                        }

                    }
                    gridHander(mediaList);
                }


            });
            msgHander("列表获取开始……");
            t.Start();
            await t;
            msgHander("列表获取结束……");
        }

        int selectIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int interval=1000;
            int.TryParse(this.tb_run_interval.Text,out interval);
            this.timer1.Interval = interval * 1000;
            if (listView1.MultiSelect == false)
            {
                listView1.Items[selectIndex++ % listView1.Items.Count].Selected = true;
            }

            GetLatestSnsTask(BindDataGridView, SetStatus, AppendConsole);
        }

        private void tb_console_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_console.TextLength >= 10000)
            {
                this.tb_console.Clear();
            }
        }

        public string Category { get; set; }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
                
            }

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.BackColor = Color.Red;
                item.ForeColor = Color.White;
                this.Category = item.Tag.ToString();
            }



        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;

            }

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.BackColor = Color.Red;
                item.ForeColor = Color.White;
                this.Category = item.Tag.ToString();
            }
        }
    }
}
