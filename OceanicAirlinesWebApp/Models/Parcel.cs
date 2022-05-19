using System.ComponentModel.DataAnnotations;

namespace OceanicAirlinesWebApp.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
    }
}
