//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace RiskRapor.Models
//{
//    public class IsKonulari
//    {
//        [Key]
//        public int IsKonuId { get; set; }
//        public int AnlasmaId { get; set; }

//        [ForeignKey("AnlasmaId")]
//        public Anlasmalar Anlasma { get; set; }

//        public string Baslik { get; set; }
//        public string Aciklama { get; set; }
//        public string RiskAnalizi { get; set; }
//        public DateTime Tarih { get; set; }
//    }
//}
