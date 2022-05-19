using System.ComponentModel.DataAnnotations;
namespace OceanicAirlinesWebApp.Models
{
    public class User
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }

    }
}
