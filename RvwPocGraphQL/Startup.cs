using System.IO;
using System.Linq;
using System.Reflection;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using RvwPocGraphQL.Resolvers;


namespace RvwPocGraphQL
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
            services.AddScoped<IDependencyResolver>
               (s => new FuncDependencyResolver(s.GetRequiredService)); 
            services.AddScoped<RootSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = false; }).AddGraphTypes(ServiceLifetime.Scoped);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddHttpContextAccessor();
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly()).Where(x => x.Name.EndsWith("Rep")).AsPublicImplementedInterfaces();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(_ => new RootSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else

            
            app.UseHttpsRedirection();
            app.UseGraphiQl();
            app.UseGraphQL<RootSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseMvc();
        }
    }
}
