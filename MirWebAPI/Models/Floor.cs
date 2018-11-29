using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirWebAPI.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        
        public Map Map { get; set; }
        public int MapId { get; set; }
    }
}
