using H.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cache
{
    class Program
    {
        public static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("******************Begin ***************************");
            SetList();
            Console.WriteLine("List Count: " + AddGet().Count);
            Console.WriteLine("List Count: " + AddGet().Count);
            Console.WriteLine("程序休眠5秒");
            Thread.Sleep(5000);
            Console.WriteLine("List Count: " + AddGet().Count);
            Delete();
            Console.WriteLine("List Count: " + AddGet().Count);
            Console.WriteLine("******************End ***************************");

            Console.Read();
        }

        public static void SetList()
        {
            Console.WriteLine("执行SetList()");
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }
        }

        /// <summary>
        /// 相对缓存,缓存时间为5秒
        /// [Caching("local", new string[] { "customerSysNo" }, ExpiryType = ExpirationType.SlidingTime, ExpireTime = "02:00:00")]
        /// </summary>
        /// <returns></returns>
        [Caching("local", ExpiryType = ExpirationType.SlidingTime, ExpireTime = "00:00:05")]
        public static List<int> AddGet()
        {
            list.Add(1);
            Console.WriteLine("执行AddGet() 该方法缓存 5秒");
            return list;
        }


        /// <summary>
        /// 清除缓存， typeof:需清楚的方法类 | 方法名 | 方法参数
        /// [FlushCache(typeof(CustomerBasicDA), "GetCustomerBasicInfoBySysNo", "entity.CustomerSysNo")]
        /// </summary>
        /// <returns></returns>
        [FlushCache(typeof(Program), "AddGet")]
        public static List<int> Delete()
        {
            Console.WriteLine("执行Delete()");
            list.RemoveAt(0);
            return list;
        }
    }
}
