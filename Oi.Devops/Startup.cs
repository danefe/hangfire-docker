using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.PostgreSql;
using Oi.Devops.Filters;

namespace Oi.Devops {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddHangfire(x => x.UsePostgreSqlStorage(Configuration.GetConnectionString("defaultConnection")));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            var dashboardoptions = new DashboardOptions {
                Authorization = new[] { new HangfireAuthFilter() }
            };
            var joboptions = new BackgroundJobServerOptions { WorkerCount = 5 };
            app.UseHangfireServer(joboptions);
            app.UseHangfireDashboard("/hangfire", dashboardoptions);

            //Fire-and-Forget
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget"));

            //Delayed
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed"), TimeSpan.FromMinutes(1));

            //Recurring
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Minutely Job"), Cron.Minutely);

            app.UseMvc();
        }
    }
}
