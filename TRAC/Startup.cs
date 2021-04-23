using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TRAC.Data;
using TRAC.DataAccess.Data;
using TRAC.Services;
using TRAC.Services.IServices;
using TRAC.Business.Repository;
using TRAC.Business.Repository.IRepository;

namespace TRAC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TRACContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IAnswerDefinitionRepository, AnswerDefinitionRepository>();
            services.AddScoped<IAnswerRepository, AnswerReporitory>();
            services.AddScoped<IChecklistDefinitionRepository, ChecklistDefinitionRepository>();
            services.AddScoped<IChecklistDefinitionStatusRepository, ChecklistDefinitionStatusRepository>();
            services.AddScoped<IChecklistRepository, ChecklistRepository>();
            services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();
            services.AddScoped<IQuestionDefinitionRepository, QuestionDefinitionRepository>();
            services.AddScoped<IQuestionDisplayConditionRepository, QuestionDisplayConditionRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISectionDefinitionRepository, SectionDefinitionRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IWBSRepository, WBSRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            dbInitializer.Initialize();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
