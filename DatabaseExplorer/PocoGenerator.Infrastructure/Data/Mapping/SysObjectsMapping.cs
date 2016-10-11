using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    class SysObjectsMapping : EntityTypeConfiguration<SysObjects>
    {
        public SysObjectsMapping()
        {
            ToTable("sys.sysobjects");
            HasKey(pk => pk.id);

            //Property(p => p.id).HasColumnName("id").HasColumnType("int");
            Property(p => p.name).HasColumnName("name").HasColumnType("nvarchar");
            Property(p => p.xtype).HasColumnName("xtype").HasColumnType("char");

            HasMany(c => c.Columns)
                .WithRequired(t => t.Table)
                .HasForeignKey(fk => fk.id);

        }
    }
}
