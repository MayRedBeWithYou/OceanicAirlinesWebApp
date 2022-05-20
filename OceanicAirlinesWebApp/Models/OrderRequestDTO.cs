namespace OceanicAirlinesWebApp.Models
{
    public class OrderRequestDTO
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Type { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
