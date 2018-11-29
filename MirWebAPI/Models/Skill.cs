using System;

namespace MirWebAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string IconUrl { get; set; }
        public string Type { get; set; }
        public string Consumption { get; set; }
        public string Training { get; set; }
        public string Explanation { get; set; }
        public string SkillUrl { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        internal Skill SelectMany()
        {
            throw new NotImplementedException();
        }
    }
}
