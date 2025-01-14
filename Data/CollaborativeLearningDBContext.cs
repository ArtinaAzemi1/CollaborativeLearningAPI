using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Data
{
    public class CollaborativeLearningDBContext : DbContext
    {
        public CollaborativeLearningDBContext(DbContextOptions<CollaborativeLearningDBContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
