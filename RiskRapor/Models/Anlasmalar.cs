using System;
using System.ComponentModel.DataAnnotations;

namespace RiskRapor.Models
{
    public class Anlasmalar
    {
        [Key]
        public int AnlasmaId { get; set; }
        public string FirmaAdi { get; set; }
        public DateTime AnlasmaTarihi { get; set; }
        public string RiskTuru { get; set; }
        public decimal RiskDegeri { get; set; }
    }
}
