using Irimies_Mircea_Proiect_Medii_de_Programare.Models;
using Irimies_Mircea_Proiect_Medii_de_Programare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Irimies_Mircea_Proiect_Medii_de_Programare.Models.TeamViewModels;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Controllers
{
    public class HomeController : Controller
    {
        private readonly TeamContext _context;
        public HomeController(TeamContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Jucators
            group order by order.EchipaID into dateGroup
            select new OrderGroup()
            {
                Echipa = dateGroup.Key,
                JucatorCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
