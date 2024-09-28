using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Table;
using RiskRapor.Data;
using RiskRapor.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace RiskRapor.Controllers
{
            

    public class MaliBilgilerController : Controller
    {
      

        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;


        public MaliBilgilerController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;

        }

        // GET: MaliBilgiler
        public async Task<IActionResult> Index()
        {
            var maliBilgiler = await _context.MaliBilgiler
                .Include(m => m.Anlasma)
                .ToListAsync();
            return View(maliBilgiler);
        }


        //EPPlus kütühanesi kuruldu tablo export işlemi için method
        public IActionResult ExportToExcel()
        {
            var maliBilgiler = _context.MaliBilgiler
                .Select(m => new {
                    Anlasma = m.Anlasma.FirmaAdi,
                    Gelir = m.Gelir,
                    Gider = m.Gider,
                    Kar = m.Kar,
                    VergiOrani = m.VergiOrani
                }).ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("MaliBilgiler");

                worksheet.Cells["A1"].LoadFromCollection(maliBilgiler, true, TableStyles.Medium9);

                var stream = new MemoryStream();
                package.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MaliBilgiler.xlsx");
            }
        }



        //public async Task<IActionResult> ExportToExcel()
        //{
        //    var maliBilgiler = await _context.MaliBilgiler
        //        .Include(m => m.Anlasma)
        //        .ToListAsync();

        //    using (var package = new ExcelPackage())
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("MaliBilgiler");
        //        worksheet.Cells["A1"].Value = "Anlaşma";
        //        worksheet.Cells["B1"].Value = "Gelir";
        //        worksheet.Cells["C1"].Value = "Gider";
        //        worksheet.Cells["D1"].Value = "Kar";
        //        worksheet.Cells["E1"].Value = "Vergi Oranı";

        //        int row = 2;
        //        foreach (var maliBilgi in maliBilgiler)
        //        {
        //            worksheet.Cells[row, 1].Value = maliBilgi.Anlasma?.FirmaAdi;
        //            worksheet.Cells[row, 2].Value = maliBilgi.Gelir;
        //            worksheet.Cells[row, 3].Value = maliBilgi.Gider;
        //            worksheet.Cells[row, 4].Value = maliBilgi.Kar;
        //            worksheet.Cells[row, 5].Value = maliBilgi.VergiOrani;
        //            row++;
        //        }

        //        var stream = new MemoryStream();
        //        package.SaveAs(stream);
        //        stream.Position = 0;
        //        string excelName = $"MaliBilgiler-{System.DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

        //        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        //    }
        //}


        //DinkToPdf kütüphanesi eklendi pdf export için method
        //DinkToPdf için gerekli dll yok 
        //libwkhtmltox.dll indirilip elle kurulacak
        public IActionResult ExportToPdf()
        {
            var maliBilgiler = _context.MaliBilgiler.Include(m => m.Anlasma).ToList();

            var sb = new StringBuilder();
            sb.Append("<h1>Mali Bilgiler</h1>");
            sb.Append("<table border='1'><tr><th>Anlaşma</th><th>Gelir</th><th>Gider</th><th>Kar</th><th>Vergi Oranı</th></tr>");

            foreach (var maliBilgi in maliBilgiler)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}%</td></tr>",
                    maliBilgi.Anlasma?.FirmaAdi, maliBilgi.Gelir, maliBilgi.Gider, maliBilgi.Kar, maliBilgi.VergiOrani);
            }

            sb.Append("</table>");

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = sb.ToString(),
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "MaliBilgiler.pdf");
        }
    }
}
