using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Pant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PantemaskinId { get; set; }
        public Pantemaskin Pantemaskin { get; set; }
        public int PantAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;



        public ICollection<PantelotteriLodd> Lodd { get; set; }
    }
}
