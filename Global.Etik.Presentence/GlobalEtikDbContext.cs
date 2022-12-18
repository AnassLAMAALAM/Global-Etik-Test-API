using Global.Etik.Domain.entities;
using Global.Etik.Domain.entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Presentence
{
    public class GlobalEtikDbContext : DbContext
    {
        public GlobalEtikDbContext(DbContextOptions<GlobalEtikDbContext> options)
: base(options)
        {
        }

        public virtual DbSet<User> User { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
