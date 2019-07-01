using Aubit.Vulcan.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aubit.Vulcan.API.Repository
{
    public class VulcanContext : DbContext
    {
        public VulcanContext(DbContextOptions options): base(options) 
        {
        }
        
        public DbSet<User> Users { get; set; }
    }
}