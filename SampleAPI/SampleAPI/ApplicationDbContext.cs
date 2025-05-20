using Microsoft.EntityFrameworkCore;
using SampleAPI.Models;

namespace SampleAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<StudentModel> Students { get; set; }
    }
}
