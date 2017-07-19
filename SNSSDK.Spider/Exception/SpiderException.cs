using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNSSDK.Spider
{
    public class SpiderException:Exception
    {
        /// <summary>  
        /// 默认构造函数  
        /// </summary>  
        public SpiderException() { }  

        public SpiderException(string message)  
            : base("爬虫异常-->"+message) 
        { 
        
        
        }
        public SpiderException(string message, Exception inner)
            : base("爬虫异常-->" + message, inner) 
        {
        
        
        } 
    }
}
