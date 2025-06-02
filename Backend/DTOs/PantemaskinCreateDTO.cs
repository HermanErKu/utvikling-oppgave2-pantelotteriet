using Backend.Models.Enums;

namespace Backend.DTOs
{
    public class PantemaskinCreateDto
    {
        public string Name { get; set; }
        public int MaxPant { get; set; }
        public int CurrentPant { get; set; }
        public Area Area { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

}
