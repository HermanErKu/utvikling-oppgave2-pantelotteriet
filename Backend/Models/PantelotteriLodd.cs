namespace Backend.Models
{
    public class PantelotteriLodd
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PantId { get; set; }
        public Pant Pant { get; set; }

        public int LotteriId { get; set; }
        public Pantelotteri Lotteri { get; set; }

        public int PantemaskinId { get; set; }
        public Pantemaskin Pantemaskin { get; set; }

        public int Barcode { get; set; }
    }
}
