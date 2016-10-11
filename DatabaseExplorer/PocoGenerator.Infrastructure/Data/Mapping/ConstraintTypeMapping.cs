using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    public class ConstraintTypeMapping:EntityTypeConfiguration<TableConstraints>
    {
        public ConstraintTypeMapping()
        {
            ToTable("INFORMATION_SCHEMA.TABLE_CONSTRAINTS");

            //Primary Key
            HasKey(pk => pk.CONSTRAINT_NAME);

            //Properties
            Property(p => p.CONSTRAINT_NAME).HasColumnName("CONSTRAINT_NAME");
            Property(p => p.CONSTRAINT_CATALOG).HasColumnName("CONSTRAINT_CATALOG");
            Property(p => p.CONSTRAINT_SCHEMA).HasColumnName("CONSTRAINT_SCHEMA");
            Property(p => p.CONSTRAINT_TYPE).HasColumnName("CONSTRAINT_TYPE");
            Property(p => p.TABLE_CATALOG).HasColumnName("TABLE_CATALOG");
            Property(p => p.TABLE_NAME).HasColumnName("TABLE_NAME");
            Property(p => p.TABLE_SCHEMA).HasColumnName("TABLE_SCHEMA");
        }
    }
}
