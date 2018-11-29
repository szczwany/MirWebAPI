using Microsoft.EntityFrameworkCore;
using MirWebAPI.Models;

namespace MirWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MapType> MapTypes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Quest> Quests { get; set; }
    }
}
