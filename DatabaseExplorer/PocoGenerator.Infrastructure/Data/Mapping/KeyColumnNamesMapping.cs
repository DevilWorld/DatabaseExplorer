using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    public class KeyColumnNamesMapping : EntityTypeConfiguration<KeyColumnUsage>
    {
        public KeyColumnNamesMapping()
        {
            ToTable("information_schema.key_column_usage");
            HasKey(pk => pk.COLUMN_NAME);

            Property(p => p.CONSTRAINT_CATALOG).HasColumnName("CONSTRAINT_CATALOG");
            Property(p => p.CONSTRAINT_SCHEMA).HasColumnName("CONSTRAINT_SCHEMA");
            Property(p => p.CONSTRAINT_NAME).HasColumnName("CONSTRAINT_NAME");
            Property(p => p.TABLE_CATALOG).HasColumnName("TABLE_CATALOG");
            Property(p => p.TABLE_SCHEMA).HasColumnName("TABLE_SCHEMA");
            Property(p => p.TABLE_NAME).HasColumnName("TABLE_NAME");
            Property(p => p.COLUMN_NAME).HasColumnName("COLUMN_NAME");
            Property(p => p.ORDINAL_POSITION).HasColumnName("ORDINAL_POSITION");

            //Relation configuration
            HasRequired(c => c.TableConstraints)
                .WithRequiredPrincipal();
        }
    }
}
