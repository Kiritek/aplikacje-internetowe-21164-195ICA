using Blog.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Blog.Areas.Identity.IdentityHostingStartup))]
namespace Blog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddTransient<IEmailSender, EmailSender>();
            });
            
        }
    }
}