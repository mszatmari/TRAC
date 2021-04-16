using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TRAC.DataAccess.Data
{
    public class TRACContext : DbContext
    {
       public DbSet<ChecklistStatus> ChecklistStatuss { get; set; }

       public TRACContext(DbContextOptions<TRACContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
