using KnesetScrapper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnesetScrapper
{
    public class DBContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.201;Database=KnesetDB;User Id=sa;Password=masterG67!;MultipleActiveResultSets=true;Trust Server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<TvShowEpisode>(e => e.HasIndex(i => new { i.SeasonId, i.EpisodeNumber }).IsUnique());
  //          modelBuilder.Entity<StoreLocation>().HasData(new StoreLocation { StoreLocationId = 1, StoreLocationName = "LevyFamily Server", StoreLocationPath = "\\\\levynas\\series" });
        }
    }
}
