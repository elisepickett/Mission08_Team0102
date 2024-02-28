using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0102.Models
{
    public class TaskSubmissionContext : DbContext
    {
        public TaskSubmissionContext(DbContextOptions<TaskSubmissionContext> options) : base(options)
        {
        }

        public DbSet<Tasklist> Tasklists { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data 
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }

            );
        }
    }
}
