using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlinesWebApp.Models
{
    public class User_Parcel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Parcel")]
        public int ParcelId { get; set; }
        public double Price { get; set; }
        public double DeliveryTime { get; set; }
    }
}
