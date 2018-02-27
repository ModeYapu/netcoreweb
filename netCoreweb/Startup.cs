using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using netCoreweb.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IO;

namespace netCoreweb
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
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Hello", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "netCoreweb.xml");
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<AddAuthTokenHeaderParameter>();
            });
            services.AddMvcCore().AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger(c =>
            {
            });
            app.UseSwaggerUI(c =>
            {
                c.ShowExtensions();
                c.ValidatorUrl(null);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "test V1");
            });
        }
    }
    /// <summary>
    /// this class is for swagger to generate AuthToken Header filed on swagger UI
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            operation.Parameters.Add(new NonBodyParameter()
            {
                Name = "token",
                In = "header",
                Type = "string",
                Description = "token认证信息",
                Required = true
            });
        }
    }
}
