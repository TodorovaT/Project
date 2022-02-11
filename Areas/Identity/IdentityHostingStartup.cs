using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Models;

[assembly: HostingStartup(typeof(Project.Areas.Identity.IdentityHostingStartup))]
namespace Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProjectContext")));

                /*services.AddDefaultIdentity<ProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ProjectUserContext>();*/
            });
        }
    }
}