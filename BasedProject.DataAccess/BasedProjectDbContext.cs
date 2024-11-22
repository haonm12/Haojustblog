using BasedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BasedProject.DataAccess
{
    public class BasedProjectDbContext : DbContext
    {
        public BasedProjectDbContext()
        {
            
        }

        public BasedProjectDbContext(DbContextOptions<BasedProjectDbContext> options) : base(options)
        {
            
        }

        //set DbSet<Entity>
    }
}
