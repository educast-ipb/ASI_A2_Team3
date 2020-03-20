using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Educast.Models;
using Educast.Data;

namespace Educast
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VideoContext>(opt =>
               opt.UseInMemoryDatabase("VideoList"));
            services.AddDbContext<DocumentContext>(opt =>
               opt.UseInMemoryDatabase("DocumentList"));
            services.AddDbContext<CanalContext>(opt =>
               opt.UseInMemoryDatabase("CanalList"));
            services.AddControllers();

            services.AddDbContext<VideoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VideoContext")));
            services.AddDbContext<DocumentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DocumentContext")));
            services.AddDbContext<CanalContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CanalContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
