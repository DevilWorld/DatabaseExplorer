using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Infrastructure.Data.Mapping;
using System.Diagnostics;

namespace PocoGenerator.Infrastructure
{
    public class PocoContext : DbContext
    {
        private readonly IConnectionStringService _connectionStringService;

        public PocoContext(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;

            Database.SetInitializer<PocoContext>(null);

            //Sets the connection string to the database, to which the objects are generated
            Database.Connection.ConnectionString = _connectionStringService.GetConnectionString();
        }

        public DbSet<SysObjects> SysObjects { get; set; }
        public DbSet<SysColumns> SysColumns { get; set; }
        public DbSet<KeyColumnUsage> KeyColumnNames { get; set; }
        public DbSet<SysTypes> SysTypes { get; set; }
        public DbSet<TableConstraints> TableConstraints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
#if DEBUG
            Database.Log = s => Debug.Write(s);
#endif

            modelBuilder.Configurations.Add(new SysObjectsMapping());
            modelBuilder.Configurations.Add(new SysColumnsMapping());
            modelBuilder.Configurations.Add(new KeyColumnNamesMapping());
            modelBuilder.Configurations.Add(new SysTypesMapping());
            modelBuilder.Configurations.Add(new ConstraintTypeMapping());
        }
    }
}
