using Microsoft.EntityFrameworkCore;
using Persistence.Models.Positions;
using Persistence.Models.Roles;

namespace Persistence.Context
{
    public class MelodiveMusicDbContext : DbContext, IMelodiveMusicDbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public MelodiveMusicDbContext(DbContextOptions<MelodiveMusicDbContext> options) : base(options)
        {
        }

        public MelodiveMusicDbContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer("Server=localhost,1433\\MSSQLSERVER19; Database=MelodiveMusic_Test; User=sa; Password=112233445566;  MultipleActiveResultSets=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Role>(builder =>
                {
                    builder.HasMany<Position>(r => r.Positions)
                        .WithOne(p => p.Role);
                    builder.HasQueryFilter(r => r.IsDeleted == false);
                    builder.HasData(new Role(1, "Admin", "A role for system administrators", "System.UserManagement.Roles.Admin"));
                    builder.HasData(new Role(2, "RegisteredUser", "A role for registered users", "System.UserManagement.Roles.RegisteredUser"));
                });

            modelBuilder
                .Entity<Position>(builder =>
                {
                    builder.HasKey(p => p.Id);
                    builder
                        .OwnsOne(p => p.PositionActivity, pa =>
                        {
                            pa.ToTable("PositionActivities");
                        })
                        .HasOne<Role>(p => p.Role)
                        .WithMany(r => r.Positions)
                        .HasForeignKey(p => p.RoleId);
                    builder.HasQueryFilter(p => p.IsDeleted == false);
                });

        }


    }
}
