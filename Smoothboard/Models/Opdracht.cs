using Microsoft.EntityFrameworkCore;

namespace Smoothboard.Models
{
    public class Opdracht
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public DateTime? DatumGebracht { get; set; }
        public DateTime? DatumOpgehaald { get; set; }
        public bool AkkoordDesign { get; set; }
        public string SurfboardDesign { get; set; } // Link/URL naar de surfboard design.
        public string Status { get; set; }
        public HoogteEnum Hoogte { get; set; }
        public BreedteEnum Lengte { get; set; }

        public Klant Klant { get; set; }

        public Opdracht()
        {
            
        }
    }

    public enum HoogteEnum // Enumeration voor de Hoogte. 
    {
        Lengte260 = 260,
        Lengte270 = 270,
        Lengte280 = 280,
        Lengte290 = 290,
        Lengte300 = 300,
        Lengte310 = 310,
        Lengte320 = 320,
        Lengte330 = 330,
        Lengte340 = 340,
        Lengte350 = 350,
        Lengte360 = 360,
        Lengte370 = 370
    }
    public enum BreedteEnum // Enumeration voor de Breedte. 
    {
        Breedte65 = 65,
        Breedte70 = 70,
        Breedte75 = 75,
        Breedte80 = 80,
        Breedte85 = 85
    }
}
