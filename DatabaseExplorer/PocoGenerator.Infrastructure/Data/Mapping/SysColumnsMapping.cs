using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    public class SysColumnsMapping : EntityTypeConfiguration<SysColumns>
    {
        public SysColumnsMapping()
        {
            ToTable("sys.syscolumns");
            HasKey(pk => pk.name);

            Property(p => p.id).HasColumnName("id").HasColumnType("int");
            Property(p => p.name).HasColumnName("name").HasColumnType("nvarchar");
            Property(p => p.colorder).HasColumnName("colorder").HasColumnType("int");
            Property(p => p.xtype).HasColumnName("xtype").HasColumnType("tinyint");            
        }
    }
}
