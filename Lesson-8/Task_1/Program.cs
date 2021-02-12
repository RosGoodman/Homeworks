using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup();
        }

        public static void Startup()
        {
            // строитель конфигурации
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                {"firstname", "Tom"},
                {"age", "31"}
                });
            // создаем конфигурацию
            AppConfiguration = builder.Build();

        }
        // свойство, которое будет хранить конфигурацию
        public static IConfiguration AppConfiguration { get; set; }

        public static void ConfigureServices(IServiceCollection services)
        {
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(AppConfiguration["firstname"]);
            });
        }
    }
}
