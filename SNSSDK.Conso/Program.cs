using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SNSSDK.Conso
{
    class Program
    {
        static void Main(string[] args)
        {
             new Program().DownLoadStringWithRetries();

             Task<int> t = new Program().DownloadAllAsync();


             Console.ReadKey();
        }


        async Task TrySomethingAsync()
        {

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task<string> DownLoadStringWithRetries()
        {
            using(var client=new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; ++i)
                {
                    try
                    {
                        Console.WriteLine(string.Format("返回{0}", i));
                        return await client.GetStringAsync("https://www.mgenware.com/blog/?p=334");
                    }
                    catch (Exception ex)
                    { 
                    
                    }
                    await Task.Delay(nextDelay);
                    nextDelay += nextDelay;
                }

                Console.WriteLine(string.Format("返回ZUIHOU"));
                return await client.GetStringAsync("https://www.mgenware.com/blog/?p=334");
            }

        }

        async Task<int> DownloadAllAsync()
        {
            Task<string> task1 = Task.FromResult("task1");
            Task<string> task2 = Task.FromResult("task2");
            Task<string> task3 = Task.FromResult("task3");
            Task<string> task4 = Task.FromResult("task4");

            object[] result = await Task.WhenAll(task1, task2, task3, task4);
            foreach (object i in result)
            {
                Console.WriteLine(i);
            }

            return 1;
        }


    }
}
