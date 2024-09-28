﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> RiskAnalizi()
        {
            var anlasmalar = await _context.Anlasmalar.ToListAsync();
            return View(anlasmalar); 
        }

        public async Task<IActionResult> GrafikVerisi()
        {
            var anlasmalar = await _context.Anlasmalar.ToListAsync();

            //  firma adı ve risk skorlarını JSON'a çevir 
            var riskVerileri = anlasmalar.Select(a => new { a.FirmaAdi, a.RiskSkoru }).ToList();

            return Json(riskVerileri);
        }

        public IActionResult Grafik()
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
                //Risk skorunu tabloya eklerken hesaplatıyoruz
                anlasma.RiskSkoru = HesaplaRiskSkoru(anlasma.RiskDegeri);
                _context.Add(anlasma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(anlasma);
        }

        private decimal HesaplaRiskSkoru(decimal riskDegeri)
        {
            return riskDegeri * 10;
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

        // Firma adına göre filtreleme metodu
        public async Task<IActionResult> FilterByFirma(string firmaAdi)
        {
            var anlasmalar = from a in _context.Anlasmalar select a;

            // Eğer firma adı boş değilse, firma adına göre filtreleme yap
            if (!string.IsNullOrEmpty(firmaAdi))
            {
                anlasmalar = anlasmalar.Where(a => a.FirmaAdi.Contains(firmaAdi));
            }

            return View(await anlasmalar.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetFirmaAdlari(string term)
        {
            var firmaAdlari = await _context.Anlasmalar
                .Where(a => a.FirmaAdi.Contains(term))
                .Select(a => a.FirmaAdi)
                .Distinct()
                .ToListAsync();

            return Json(firmaAdlari);
        }

    }
}
