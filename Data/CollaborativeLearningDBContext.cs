﻿using CollaborativeLearningAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Resources;

namespace CollaborativeLearningAPI.Data
{
    public class CollaborativeLearningDBContext : DbContext
    {
        public CollaborativeLearningDBContext(DbContextOptions<CollaborativeLearningDBContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Assistant> Assistant { get; set; }
        public DbSet<Coordinator> Coordinator { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Assistant>().ToTable("Assistant");
            modelBuilder.Entity<Coordinator>().ToTable("Coordinator");

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(t => t.TaskId);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coordinator>()
                .HasOne(c => c.Schedule)
                .WithOne(s => s.Coordinator)
                .HasForeignKey<Schedule>(s => s.CoordinatorId);

            modelBuilder.Entity<Group>()
               .HasOne(g => g.Schedule)
               .WithOne(s => s.Group)
               .HasForeignKey<Schedule>(s => s.GroupId);

        }
    }
}
