using Backend.Models.Enums;
namespace Backend.DTOs
{
    public class PantCreateDto
    {
        public int UserId { get; set; }
        public int PantemaskinId { get; set; }
        public int PantAmount { get; set; }
    }

}