using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiskRapor.Models
{
    public class Anlasmalar
    {
        [Key]
        public int AnlasmaId { get; set; }
        public string FirmaAdi { get; set; }
        public DateTime AnlasmaTarihi { get; set; }
        public string RiskTuru { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RiskDegeri { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RiskSkoru { get; set; }

        public ICollection<MaliBilgiler>? MaliBilgiler { get; set; }
    }
}
