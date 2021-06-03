using Microsoft.EntityFrameworkCore;
using Persistence.Models.Positions;
using Persistence.Models.Roles;

namespace Persistence.Context
{
    public interface IMelodiveMusicDbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}