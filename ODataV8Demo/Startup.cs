using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataV8Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV8Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
            .AddRouteComponents("api/accounts", edmModelAccounts())
           .AddRouteComponents("api/devices", edmModelDevices()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

        /// <summary>
        ///  Get entity data model - Accounts
        /// </summary>
        public static IEdmModel edmModelAccounts()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Accounts>("Accounts");

            return builder.GetEdmModel();
        }

        /// <summary>
        ///  Get entity data model - Devices
        /// </summary>
        public static IEdmModel edmModelDevices()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Devices>("Devices");

            return builder.GetEdmModel();
        }

    }
}
