using Microsoft.AspNetCore.Mvc;
using RiskRapor.Models;
using RiskRapor.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RiskRapor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;  // DbContext'i constructor'dan alıyoruz
        }

        public async Task<IActionResult> Index()
        {
            // Track etmeyi durdurarak hafıza yükünü azaltma işlemi için AsNoTracking eklendi
            var anlasmalar = await _context.Anlasmalar.AsNoTracking().ToListAsync();

            return View(anlasmalar);
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
