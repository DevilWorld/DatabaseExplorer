using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Domain.DotLiquidDrops
{
    public class TableWithColumnsDrop : Drop
    {
        private readonly SysObjects _sysObjects;

        public TableWithColumnsDrop(SysObjects sysObjects)
        {
            _sysObjects = sysObjects;
        }

        #region Properties

        public string Name => _sysObjects.name;
        public IList<SysColumns> Columns => _sysObjects.Columns;

        #endregion
    }
}
