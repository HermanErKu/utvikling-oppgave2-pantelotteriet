namespace Backend.DTOs
{
    public class PantelotteriLoddCreateDto
    {
        public int UserId { get; set; }
        public int PantId { get; set; }
        public int LotteriId { get; set; }
        public int PantemaskinId { get; set; }
        public int Barcode { get; set; }
    }
}
