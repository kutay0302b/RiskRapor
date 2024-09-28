using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRapor.Data;
using RiskRapor.Models;
using System.Threading.Tasks;

namespace RiskRapor.Controllers
{
    public class MaliBilgilerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaliBilgilerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaliBilgiler
        public async Task<IActionResult> Index()
        {
            var maliBilgiler = await _context.MaliBilgiler
                .Include(m => m.Anlasma)
                .ToListAsync();
            return View(maliBilgiler);
        }

    }
}
