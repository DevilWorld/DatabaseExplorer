using System;
using System.Collections.Generic;
using System.Linq;
using PocoGenerator.Domain.Models;
using DotLiquid;
using PocoGenerator.Domain.Models.BaseObjects;
//using PocoGenerator.Common;

namespace PocoGenerator.Domain.DotLiquidDrops
{
    public class SysColumnsDrop : Drop
    {
        private readonly SysColumns _sysColumns;       

        public SysColumnsDrop(SysColumns sysColumns)
        {
            _sysColumns = sysColumns;            
        }

        public string name => _sysColumns.name;
        public string datatype => Global.DataTypeMapper[_sysColumns.DataType.name];
        //public string datatype => _sysColumns.DataType.name;        //comment this and uncomment the above line. Above line works, if 
        //it works in the correct flow. For test object, it does not work.
    }
}
