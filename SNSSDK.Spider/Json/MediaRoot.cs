using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNSSDK.Spider.Json
{

    [Serializable]
    public class MediaBase
    {

        public long item_id { get; set; }
        public long group_id { get; set; }
        public string title { get; set; }
        public string media_name { get; set; }
        public int read_count { get; set; }
        public string keywords { get; set; }
        public string source { get; set; }
        public int comment_count { get; set; }
        public string article_url { get; set; }
        public int share_count { get; set; }
        public int publish_time { get; set; }
        public int like_count { get; set; }
        public string url { get; set; }
        public int ban_comment { get; set; }
        public int tip { get; set; }
        public int hot { get; set; }


        public string _abstract { get; set; }
        public int article_type { get; set; }
        public string tag { get; set; }
        public int has_m3u8_video { get; set; }

        public string rid { get; set; }
        public int user_verified { get; set; }
        public int aggr_type { get; set; }
        public int cell_type { get; set; }
        public int article_sub_type { get; set; }
        public int bury_count { get; set; }

        public int ignore_web_transform { get; set; }
        public int source_icon_style { get; set; }

        public string share_url { get; set; }
        public int has_mp4_video { get; set; }

        public int gallary_image_count { get; set; }
        public int cell_layout_style { get; set; }
        public long tag_id { get; set; }
        public string action_extra { get; set; }
        public int video_style { get; set; }
        public string verified_content { get; set; }
        public string display_url { get; set; }


        public int repin_count { get; set; }
        public int cell_flag { get; set; }
        public string source_open_url { get; set; }
        public int level { get; set; }

        public int digg_count { get; set; }
        public int behot_time { get; set; }
        public long cursor { get; set; }
 
        public int preload_web { get; set; }
        public int user_repin { get; set; }

        public int item_version { get; set; }


    }

    [Serializable]
    public class MediaRoot : MediaBase
    {
    public Log_Pb log_pb { get; set; }

    public Image_List[] image_list { get; set; }
    public Ugc_Recommend ugc_recommend { get; set; }

    public Forward_Info forward_info { get; set; }
 
    public bool show_portrait_article { get; set; }
  
    public Filter_Words[] filter_words { get; set; }

    public Action_List[] action_list { get; set; }
 
    public object[] large_image_list { get; set; }
    public Media_Info media_info { get; set; }

    public User_Info user_info { get; set; }
 
    public bool has_image { get; set; }

    public bool has_video { get; set; }

    public Middle_Image middle_image { get; set; }
    }
    [Serializable]
    public class Log_Pb
    {
    public string impr_id { get; set; }
    }
    [Serializable]
    public class Ugc_Recommend
    {
    public string reason { get; set; }
    public string activity { get; set; }
    }
    [Serializable]
    public class Forward_Info
    {
    public int forward_count { get; set; }
    }
    [Serializable]
    public class Media_Info
    {
    public long user_id { get; set; }
    public string verified_content { get; set; }
    public string avatar_url { get; set; }
    public long media_id { get; set; }
    public string name { get; set; }
    public int recommend_type { get; set; }
    public bool follow { get; set; }
    public string recommend_reason { get; set; }
    public bool is_star_user { get; set; }
    public bool user_verified { get; set; }
    }
    [Serializable]
    public class User_Info
    {
    public string verified_content { get; set; }
    public string avatar_url { get; set; }
    public long user_id { get; set; }
    public string name { get; set; }
    public int follower_count { get; set; }
    public bool follow { get; set; }
    public string user_auth_info { get; set; }
    public bool user_verified { get; set; }
    public string description { get; set; }
    }
    [Serializable]
    public class Middle_Image
    {
    public string url { get; set; }
    public int width { get; set; }
    public Url_List[] url_list { get; set; }
    public string uri { get; set; }
    public int height { get; set; }
    }
    [Serializable]
    public class Url_List
    {
    public string url { get; set; }
    }
    [Serializable]
    public class Image_List
    {
    public string url { get; set; }
    public int width { get; set; }
    public Url_List1[] url_list { get; set; }
    public string uri { get; set; }
    public int height { get; set; }
    }
    [Serializable]
    public class Url_List1
    {
    public string url { get; set; }
    }
    [Serializable]
    public class Filter_Words
    {
    public string id { get; set; }
    public string name { get; set; }
    public bool is_selected { get; set; }
    }
    [Serializable]
    public class Action_List
    {
    public int action { get; set; }
    public Extra extra { get; set; }
    public string desc { get; set; }
    }
    [Serializable]
    public class Extra
    {
    }

}
