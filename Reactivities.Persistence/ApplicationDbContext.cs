using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;

namespace Reactivities.Persistence;

public class ApplicationDbContext : DbContext
{
   public DbSet<Activity> Activities => Set<Activity>();

   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
   {
   }
}
