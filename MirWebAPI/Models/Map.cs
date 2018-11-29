using System;
using System.Collections.Generic;

namespace MirWebAPI.Models
{
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<Monster> Monsters { get; set; }
        public ICollection<Npc> Npcs { get; set; }
        public ICollection<Floor> Floors { get; set; }
    }
}
