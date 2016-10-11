using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.BaseObjects
{
    public class SysColumns
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte colorder { get; set; }
        public byte xtype { get; set; }

        public virtual SysObjects Table { get; set; }

        public virtual SysTypes DataType { get; set; }
    }
}
