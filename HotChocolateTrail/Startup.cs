using System.Linq;
using System.Reflection;
using GraphiQl;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolateTrail.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace HotChocolateTrail
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly()).Where(x => x.Name.EndsWith("Rep")).AsPublicImplementedInterfaces();
            services.AddGraphQL(sp => SchemaBuilder.New()
               .AddServices(sp)
               .AddQueryType<QueryType>()
               .Create());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
            app
                .UseWebSockets()
                .UseGraphQL("/graphql")
                .UseGraphiQl("/graphql")
                .UsePlayground("/graphql");
        }
    }
}
