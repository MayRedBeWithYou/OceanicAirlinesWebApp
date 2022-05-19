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
        public string Size
        {
            get; set;
        }
        [NotMapped]
        public string CalculatedSize
        {
            get
            {
                if (Height < 25 && Width < 25 && Length < 25) return "A";
                else if (Height < 40 && Width < 40 && Length < 40) return "B";
                else if (Height < 200 && Width < 200 && Length < 200) return "C";
                else return "Unsupported";
            }
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        [ForeignKey("Category")]
        public int Category { get; set; }
    }
}
