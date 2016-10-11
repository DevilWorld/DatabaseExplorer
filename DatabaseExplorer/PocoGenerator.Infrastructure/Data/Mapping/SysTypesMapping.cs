using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    public class SysTypesMapping : EntityTypeConfiguration<SysTypes>
    {
        public SysTypesMapping()
        {
            //Table configuration
            ToTable("sys.systypes");

            //Primary key configuration
            HasKey(pk => pk.xtype);

            //Property-column mapping
            Property(p => p.name).HasColumnName("name").HasColumnType("nvarchar");
            Property(p => p.xtype).HasColumnName("xtype").HasColumnType("tinyint");

            //Relation
            HasMany(c => c.Columns)
                .WithRequired(t => t.DataType)
                .HasForeignKey(fk => fk.xtype);
        }
    }
}
