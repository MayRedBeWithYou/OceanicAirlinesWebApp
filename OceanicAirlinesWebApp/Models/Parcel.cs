using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Category")]
        public int Category { get; set; }
    }
}
