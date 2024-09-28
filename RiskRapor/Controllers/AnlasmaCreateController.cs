using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRapor.Data;
using RiskRapor.Models;
using System.Threading.Tasks;

namespace RiskRapor.Controllers
{
    public class AnlasmaCreateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnlasmaCreateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnlasmaCreate/Create (Yeni Anlaşma Ekleme Formu)
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnlasmaCreate/Create (Yeni Anlaşma Veritabanına Kaydedilir)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirmaAdi,AnlasmaTarihi,RiskTuru,RiskDegeri")] Anlasmalar anlasma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anlasma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(anlasma);
        }

        // GET: AnlasmaCreate/Edit/5 (ID'ye göre düzenleme formunu gösterir)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anlasma = await _context.Anlasmalar.FindAsync(id);
            if (anlasma == null)
            {
                return NotFound();
            }
            return View(anlasma);
        }

        // POST: AnlasmaCreate/Edit/5 (Düzenlenen veriyi veritabanına kaydeder)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnlasmaId,FirmaAdi,AnlasmaTarihi,RiskTuru,RiskDegeri")] Anlasmalar anlasma)
        {
            if (id != anlasma.AnlasmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anlasma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnlasmaExists(anlasma.AnlasmaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(anlasma);
        }

        private bool AnlasmaExists(int id)
        {
            return _context.Anlasmalar.Any(e => e.AnlasmaId == id);
        }

        // GET: AnlasmaCreate/Delete/5 (Silme onay sayfası)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anlasma = await _context.Anlasmalar
                .FirstOrDefaultAsync(m => m.AnlasmaId == id);
            if (anlasma == null)
            {
                return NotFound();
            }

            return View(anlasma);
        }

        // POST: AnlasmaCreate/Delete/5 (Silme işlemini yapar)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anlasma = await _context.Anlasmalar.FindAsync(id);
            _context.Anlasmalar.Remove(anlasma);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
