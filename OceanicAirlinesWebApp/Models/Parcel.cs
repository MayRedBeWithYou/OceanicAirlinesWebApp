using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlinesWebApp.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
        public double Price { get; set; }
        public double Time { get; set; }

        [ForeignKey("Category")]
        public int Category { get; set; }

        [NotMapped]
        public static List<Category> Categories { get; } = new List<Category>()
        {
            new Category()
            {
                Id = 0,
                Name = "Standard",
                AddedPrice = 1,
            },
            new Category()
            {
                Id = 1,
                Name = "Live animals",
                AddedPrice = -1,
            },
            new Category()
            {
                Id = 2,
                Name = "Dead animals",
                AddedPrice = -1,
            },
            new Category()
            {
                Id = 3,
                Name = "Refrigerated",
                AddedPrice = 1.10,
            },
            new Category()
            {
                Id = 4,
                Name = "Children",
                AddedPrice = -1,
            },
            new Category()
            {
                Id = 5,
                Name = "Cautious",
                AddedPrice = 1.75,
            },
            new Category()
            {
                Id = 6,
                Name = "Furniture",
                AddedPrice = 1,
            },
            new Category()
            {
                Id = 7,
                Name = "Weapons",
                AddedPrice = 2,
            },
            new Category()
            {
                Id = 8,
                Name = "Recorded",
                AddedPrice = -1,
            }
        };
    }
}
