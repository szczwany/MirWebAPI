namespace MirWebAPI.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKR { get; set; }
        public string Level { get; set; }
        public string ImageUrl { get; set; }
        public string Alive { get; set; }
        public string Tame { get; set; }
        public string Experience { get; set; }
        public string Attack { get; set; }
        public string Defence { get; set; }
        public string Fire { get; set; }
        public string Cold { get; set; }
        public string Light { get; set; }
        public string Wind { get; set; }
        public string Holy { get; set; }
        public string Dark { get; set; }
        public string Phantom { get; set; }
        public string BC { get; set; }
        public string Items { get; set; }
        public string Description { get; set; }

        public Map Map { get; set; }
        public int MapId { get; set; }
    }
}
