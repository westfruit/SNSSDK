using CsharpHttpHelper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SNSSDK.Spider.Hander
{
    public class BaseHander
    {
        /// <summary>
        /// 调用接口
        /// </summary>
        /// <returns></returns>
        public T CallApi<T>(string url, object postBody) where T : new()
        {
            IRestResponse response = null;
            try
            {
                RestClient restclient = new RestClient(url);

                RestRequest restrequest = new RestRequest(RestSharp.Method.POST);

                restclient.Proxy = this.RequestProxy;
                restclient.UserAgent = "User-Agent: Dalvik/2.1.0 (Linux; U; Android 5.1.1; ZTE B2015 Build/LMY47V)";

                restrequest.RequestFormat = DataFormat.Json;
                restrequest.AddJsonBody(postBody);


                response = restclient.Execute(restrequest);
            }
            catch (Exception ex)
            {
                var cartex = new SpiderException(string.Format("调用接口异常---" + ex.Message + ",url:{0},postBody={1}", url, postBody), ex);
                throw cartex;//向上抛出顶层统一处理
            }
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                //throw new Exception(string.Format("调用接口:{restclient},异常：{1}", url, response.StatusDescription) + response.StatusDescription, new WebException());
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// 调用接口
        /// </summary>
        /// <returns></returns>
        public T CallUrl<T>(string url, object postBody) where T : new()
        {
            HttpHelper urlClient = new HttpHelper();

            string response="";

            try
            {
                var header = new WebHeaderCollection() { };
                header.Add("X-SS-REQ-TICKET", "1500211963974");

                
                HttpResult httpResult = urlClient.GetHtml(
                    new HttpItem() { 
                        URL = url, 
                        Accept = "application/json", 
                        Method="get",
                        Referer = "http://lf.snssdk.com/",
                        Header = header,
                        ContentType = "application/octet-stream;tt-data=a",
                        Cookie = "qh[360]=1; install_id=12300006309; ttreq=1$e776526bce6dab78f1b34e98867bec496951e17e",
                        UserAgent = this.UserAgent, 
                        WebProxy = this.RequestProxy });
                response = httpResult.Html;

            }
            catch (Exception ex)
            {
                var cartex = new SpiderException(string.Format("调用接口异常---" + ex.Message + ",url:{0},postBody={1}", url, postBody), ex);
                throw cartex;//向上抛出顶层统一处理
            }

            return JsonConvert.DeserializeObject<T>(response);
        }


        public WebProxy RequestProxy
        {
            get;
            set;
        }

        public string Head
        {
            get;
            set;
        }

        public string UserAgent
        {
            get;
            set;
        }
    }
}
