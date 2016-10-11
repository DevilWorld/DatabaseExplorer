using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.BaseObjects
{
    public class SysTypes
    {
        public string name { get; set; }
        public byte xtype { get; set; }

        public virtual IList<SysColumns> Columns { get; set; }
    }
}
