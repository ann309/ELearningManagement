using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELearning.DAL
{
    public class ELearningDBContext : IdentityDbContext<UserInformation>
    {
        public ELearningDBContext() { }

        public ELearningDBContext(DbContextOptions<ELearningDBContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Documentation> Documentations { get; set; }

        public DbSet<Calender> Calender { get; set; }
        public DbSet<Chat> Chats { get; set; }
        
        public DbSet<Upload> Uploads { get; set; }

        public DbSet<Assigned> Assign { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Upload>()
                .HasOne<UserInformation>(u => u.User)
                .WithMany(c => c.Uploads)
                .HasForeignKey(c => c.UserID);

            modelBuilder.Entity<Calender>()
                .HasOne<UserInformation>(u => u.User)
                .WithMany(c => c.CalenderEvents)
                .HasForeignKey(c => c.UserID);
        }

    }
}
