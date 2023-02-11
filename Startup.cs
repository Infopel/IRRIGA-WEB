using IRRIGA.Data;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA
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
            services.AddScoped<IInqueritosRepository, InqueritosRepository>();
            services.AddScoped<IFieldsetsRepository, FieldsetsRepository>();
            services.AddScoped<IInqueritoPerguntasRepository, InqueritoPerguntasRepository>();
            services.AddScoped<IInqueritoRespostasRepository, InqueritoRespostasRepository>();
            services.AddScoped<IBeneficiariosRepository, BeneficiariosRepository>();
            services.AddScoped<IOpcoesPerguntaRepository, OpcoesPerguntaRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IResponsesInqueritoRepository, ResponsesInqueritoRepository>();
            services.AddScoped<IRegadiosRepository, RegadiosRepository>();
            services.AddScoped<IAssociacoesRespository, AssociacoesRepository>();
            services.AddScoped<ICulturasRepository, CulturasRepository>();
            services.AddScoped<IEscolaMachambasRepository, EscolaMachambasRepository>();
            services.AddScoped<IProvincesRepository, ProvincesRepository>();

            services.AddDbContext<dbIRRIGAContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<dbIRRIGAContext>();
            services.AddMvc().AddControllersAsServices();
            services.AddControllersWithViews();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddMvc();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler(c => c.Run(async context =>
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                    var response = new { error = exception.Message };
                    await context.Response.WriteAsJsonAsync(response);
                }));

                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
