using Backend.Models.Enums;
using System.Collections.Generic;

namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }



        public ICollection<Pant> PantedItems { get; set; }
        public ICollection<PantelotteriLodd> LotteryTickets { get; set; }
        public ICollection<Pantelotteri> WonLotteries { get; set; }
    }
}
