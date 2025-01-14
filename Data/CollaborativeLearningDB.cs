using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeLearningAPI.Data
{
    public class CollaborativeLearningDB : DbContext
    {
        public CollaborativeLearningDB(DbContextOptions<CollaborativeLearningDB> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
