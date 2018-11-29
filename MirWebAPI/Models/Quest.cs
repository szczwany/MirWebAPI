using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirWebAPI.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string IconUrl { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }
        public string Condition { get; set; }
        public string Reward { get; set; }
        public string PrecedingQuest { get; set; }
        public string StartLocation { get; set; }
        public string CompleteLocation { get; set; }
        public string Description { get; set; }
    }
}
