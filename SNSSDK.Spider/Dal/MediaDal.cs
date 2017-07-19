using SNSSDK.Spider.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace SNSSDK.Spider.Dal
{
    public partial class MediaDal: DalBase
    {
        public int Add(MediaBase media)
        {
            int result = 0;
            string sql = "INSERT INTO media (item_id, group_id, title, media_name, keywords, read_count, source, comment_count, article_url, share_count, publish_time)   VALUES (@item_id, @group_id, @title, @media_name, @keywords, @read_count, @source, @comment_count, @article_url, @share_count, @publish_time)";
            using (IDbConnection conn = GetConnection("default"))
            {
                conn.Open();

                result = conn.Execute(sql, media);
            }
            return result;
        }
    }
}
