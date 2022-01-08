using System;
using Irimies_Mircea_Proiect_Medii_de_Programare.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Irimies_Mircea_Proiect_Medii_de_Programare.Areas.Identity.IdentityHostingStartup))]
namespace Irimies_Mircea_Proiect_Medii_de_Programare.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Irimies_Mircea_Proiect_Medii_de_ProgramareContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Irimies_Mircea_Proiect_Medii_de_ProgramareContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Irimies_Mircea_Proiect_Medii_de_ProgramareContext>();
            });
        }
    }
}