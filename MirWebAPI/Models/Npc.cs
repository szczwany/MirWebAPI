using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirWebAPI.Models
{
    public class Npc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string Description { get; set; }
        public string Quest { get; set; }
        public string Location { get; set; }
        public string Explanation { get; set; }
        public string ImageUrl { get; set; }

        public Map Map { get; set; }
        public int MapId { get; set; }
    }
}
