using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WadApplication.Data;

[assembly: HostingStartup(typeof(WadApplication.Areas.Identity.IdentityHostingStartup))]
namespace WadApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WadApplicationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WadApplicationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WadApplicationContext>();
            });
        }
    }
}