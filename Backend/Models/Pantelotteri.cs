using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Pantelotteri
    {
        public int Id { get; set; }
        public DateTime DrawDate { get; set; }
        public int? WinnerUserId { get; set; }
        
        
        public User Winner { get; set; }
        public ICollection<PantelotteriLodd> Tickets { get; set; }
    }
}
