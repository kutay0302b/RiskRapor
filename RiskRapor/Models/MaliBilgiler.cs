namespace RiskRapor.Models
{
    public class MaliBilgiler
    {
        public int Id { get; set; }
        public int AnlasmaId { get; set; }  
        public decimal Gelir { get; set; }
        public decimal Gider { get; set; }
        public decimal Kar { get; set; }
        public decimal VergiOrani { get; set; }

        public Anlasmalar? Anlasma { get; set; }
    }

    public class MaliBilgilerDto
    {
        public int Id { get; set; }
        public decimal Gelir { get; set; }
        public decimal Gider { get; set; }
        public decimal Kar { get; set; }
        public decimal VergiOrani { get; set; }
    }
}
