using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRAC.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TRAC.Areas.Identity.IdentityHostingStartup))]
namespace TRAC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TRACIdentityDbContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("TRACIdentityDbContextConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<TRACIdentityDbContext>().AddDefaultUI();
            });
        }
    }
}