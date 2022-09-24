using GymManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-V2VUQSM; Database=GymManagement;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>(m =>
            {
                m.ToTable("Members").HasKey(k => k.Id);
                m.Property(p => p.Id).HasColumnName("Id");
                m.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
                m.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
                m.Property(p => p.TrainerId).HasColumnName("TrainerId");
                m.Property(p => p.FirstName).HasColumnName("FirstName");
                m.Property(p => p.LastName).HasColumnName("LastName");
                m.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                m.Property(p => p.Weight).HasColumnName("Weight");
                m.Property(p => p.Height).HasColumnName("Height");
                m.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                m.Property(p => p.Email).HasColumnName("Email");
                m.Property(p => p.Status).HasColumnName("Status");
                m.HasOne(p => p.Trainer);
            });

            modelBuilder.Entity<Trainer>(t =>
            {
                t.ToTable("Trainers").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
                t.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
                t.Property(p => p.FirstName).HasColumnName("FirstName");
                t.Property(p => p.LastName).HasColumnName("LastName");
                t.Property(p => p.Branch).HasColumnName("Branch");
                t.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                t.Property(p => p.Email).HasColumnName("Email");
                t.Property(p => p.Status).HasColumnName("Status");
                t.HasMany(p => p.Members);
            });
        }
    }
}
