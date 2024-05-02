using DTO;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context;

public class MatchPadelContext : DbContext
{
    public MatchPadelContext(DbContextOptions<MatchPadelContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<GameType> GameTypes { get; set; }
    public DbSet<Set> Sets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>().HasKey(r => new { r.MatchRefId, r.UserRefId });
        modelBuilder.Entity<Set>().HasKey(s => new { s.MatchRefId, s.Number });
    }
}