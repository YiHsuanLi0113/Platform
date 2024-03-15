using Microsoft.EntityFrameworkCore;
using PlatformService.Models;


namespace PlatformService.Data;
//using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
       
    }
    //using PlatformService.Models;
    public DbSet<Platform> Platforms { get; set; }
}
