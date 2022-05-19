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

        [NotMapped]
        public static List<Category> Categories { get; } = new List<Category>()
        {
            new Category()
            {
                Id = 0,
                Name = "Standard",
                AddedPrice = 0,
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
