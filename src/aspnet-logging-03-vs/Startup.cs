namespace aspnet_logging_03_vs
{
    using System;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.EventLog;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyClass>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;

            var settings = new EventLogSettings
            {
                SourceName = "Log App",
                Filter = (source, level) => level >= LogLevel.Information
            };

            loggerFactory.AddEventLog(settings);

            app.UseIISPlatformHandler();

            app.Run(async context =>
            {
                var myClass = context.RequestServices.GetService<MyClass>();

                myClass.DoSomething(1);
                myClass.DoSomething(20);
                myClass.DoSomething(-20);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}