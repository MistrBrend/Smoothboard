namespace Smoothboard.Models
{
    public class OpdrachtTest
    {
        public int Id { get; set; }
        public string KlantNaam { get; set; }
        public DateTime? DatumGebracht { get; set; }
        public DateTime? DatumOpgehaald { get; set; }
        public bool AkkoordDesign { get; set; }
        public string SurfboardDesign { get; set; }
        public string Status { get; set; }
        public LengteEnum Lengte { get; set; }
        public BreedteEnum Breedte { get; set; }
    }

}
