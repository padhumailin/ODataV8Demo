using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter.Deserialization;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.AspNetCore.OData.Routing.Template;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataETagWebApi.Extensions;
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

            services.AddControllers().AddOData(option =>
            {
                option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
                .AddRouteComponents("api/accounts", edmModelAccounts(),
                builder => builder.AddSingleton<IODataSerializerProvider, ETagSerializerProvider>()
                                  .AddSingleton<IODataDeserializerProvider, ETagDeserializerProvider>())
               .AddRouteComponents("api/devices", edmModelDevices(),
                builder => builder.AddSingleton<IODataSerializerProvider, ETagSerializerProvider>()
                                  .AddSingleton<IODataDeserializerProvider, ETagDeserializerProvider>())
               .AddRouteComponents("api", fakeModel()) // is required to build the service provider for "api/"
               .Conventions.Remove(option.Conventions.First(convention => convention is MetadataRoutingConvention));

                option.Conventions.Add(new MyRoutingConvention());
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseODataRouteDebug();

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

        public static IEdmModel fakeModel()
        {
            EdmModel model = new EdmModel();
            EdmEntityContainer container = new EdmEntityContainer("NS", "Default");
            model.AddElement(container);
            return model;
        }

    }

    public class MyRoutingConvention : IODataControllerActionConvention
    {
        public int Order => -999;

        public bool AppliesToController(ODataControllerActionContext context)
        {
            return true;
        }

        public bool AppliesToAction(ODataControllerActionContext context)
        {
            if (context.Action.ActionName == "GetDevices")
            {
                IEdmEntitySet devices = context.Model.EntityContainer.FindEntitySet("Devices");
                if (devices != null)
                {
                    context.Action.Selectors.Clear();

                    ODataPathTemplate path = new ODataPathTemplate(
                        new EntitySetSegmentTemplate(devices)
                    );
                    context.Action.AddSelector("get", "api", context.Model, path, context.Options.RouteOptions);

                    return true;
                }
            }

            if (context.Action.ActionName == "GetAccounts")
            {
                IEdmEntitySet devices = context.Model.EntityContainer.FindEntitySet("Accounts");
                if (devices != null)
                {
                    context.Action.Selectors.Clear();

                    ODataPathTemplate path = new ODataPathTemplate(
                        new EntitySetSegmentTemplate(devices)
                    );
                    context.Action.AddSelector("get", "api", context.Model, path, context.Options.RouteOptions);

                    return true;
                }
            }


            return false;
        }
    }
}
