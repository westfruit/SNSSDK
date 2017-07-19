using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNSSDK.Spider.Json
{
    [Serializable]
    public class ListRoot
    {
        public int login_status { get; set; }
        public int total_number { get; set; }
        public bool has_more { get; set; }
        public string post_content_hint { get; set; }
        public object[] sub_entrance_list { get; set; }
        public int show_et_status { get; set; }
        public int feed_flag { get; set; }
        public string message { get; set; }
        public bool has_more_to_refresh { get; set; }
        public Datum[] data { get; set; }
        public Tips tips { get; set; }
    }
    [Serializable]
    public class Tips
    {
        public string display_info { get; set; }
        public string open_url { get; set; }
        public string web_url { get; set; }
        public string app_name { get; set; }
        public string package_name { get; set; }
        public string display_template { get; set; }
        public string type { get; set; }
        public int display_duration { get; set; }
        public string download_url { get; set; }
    }

    [Serializable]
    public class Datum
    {
        public string content { get; set; }
        public string code { get; set; }
    }

}
