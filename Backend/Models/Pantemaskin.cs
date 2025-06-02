using System.Collections.Generic;
using Backend.Models.Enums;

namespace Backend.Models
{
    public class Pantemaskin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPant { get; set; }
        public int CurrentPant { get; set; }
        public Area Area { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }



        public ICollection<Pant> PantedItems { get; set; }
        public ICollection<PantelotteriLodd> Lodd { get; set; }
    }
}
