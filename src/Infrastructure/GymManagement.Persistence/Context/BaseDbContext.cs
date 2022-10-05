using GymManagement.Domain.Common;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; } 

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

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.Property(p => p.Status).HasColumnName("Status");
                u.HasMany(p => p.RefreshTokens);
                u.HasMany(p => p.UserOperationClaims);
            });

            modelBuilder.Entity<UserOperationClaim>(uoc =>
            {
                uoc.ToTable("UserOperationClaims").HasKey(k => k.Id);
                uoc.Property(p => p.UserId);
                uoc.Property(p => p.OperationClaimId);

            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTimeOffset.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTimeOffset.UtcNow,
                    _ => DateTimeOffset.UtcNow
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTimeOffset.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTimeOffset.UtcNow,
                    _ => DateTimeOffset.UtcNow
                };
            }
            return base.SaveChanges();
        }
    }
}
