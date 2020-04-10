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
        /// �������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //����IWebHostBuilder-������IWebHost-��Ȼ�����д�����IWebHost��

            CreateHostBuilder(args)//�������淽��������һ��IWebHostBuilder����
                .Build()    //�����淵�ص�IWebHostBuilder���󴴽�һ��IWebHost
                .Run();     //�������洴����IWebHost����Ӷ��������ǵ�WebӦ�ó�������һ��һֱ���м���http���������
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostBuilderʵ��
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
                    webBuilder.UseStartup<Startup>();   //ΪWeb Hostָ��Startup��
                });
    }
}
