using DTO;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context;

public partial class MatchPadelContext : DbContext 
{
   public MatchPadelContext(DbContextOptions<MatchPadelContext> options) : base(options)
   {
      
   }
   
   public virtual DbSet<User> Users { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      OnModelCreatingPartial(modelBuilder);   
   }

   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}