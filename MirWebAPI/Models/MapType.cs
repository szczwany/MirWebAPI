using System.Collections.Generic;

namespace MirWebAPI.Models
{
    public class MapType
    {
        public int Id { get; set; }
        public string LevelRange { get; set; }
        public string Description { get; set; }
        public string DescriptionKR { get; set; }
        
        public ICollection<Map> Maps { get; set; }
    }
}
