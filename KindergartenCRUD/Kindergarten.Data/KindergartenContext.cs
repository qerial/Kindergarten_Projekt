using Microsoft.EntityFrameworkCore;
using Kindergarten.Core.Domain;
namespace Kindergarten.Data

{
    public class KindergartenContext : DbContext
    {
        public KindergartenContext(DbContextOptions<KindergartenContext> options) : base (options)
        { 
        
        }
        public DbSet<KindergartenDomain> Kindergartens { get; set; }
    }
}
