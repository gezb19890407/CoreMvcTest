using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestCore
{
    public class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //创建IWebHostBuilder-》创建IWebHost-》然后运行创建的IWebHost。

            CreateHostBuilder(args)//调用下面方法，返回一个IWebHostBuilder对象
                .Build()    //用上面返回的IWebHostBuilder对象创建一个IWebHost
                .Run();     //运行上面创建的IWebHost对象从而运行我们的Web应用程序，启用一个一直运行监听http请求的任务
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //使用默认的配置信息来初始化一个新的IWebHostBuilder实例
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();   //为Web Host指定Startup类
                });
    }
}
