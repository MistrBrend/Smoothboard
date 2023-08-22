namespace Smoothboard.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Telefoonnummer { get; set; }
        public string Emailadres { get; set; }
        public Boolean EigenSurfboardDesign { get; set; }
        public ICollection<Opdracht> Opdrachten { get; set; } = new List<Opdracht>();

        public Klant()
        {
            
        }
    }
}
