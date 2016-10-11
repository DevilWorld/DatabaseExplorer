using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Domain.Models.Dto
{
    public class TablesWithColumnsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<SysColumns> Columns { get; set; }
        public List<ColumnsWithKeysDto> ColumnsWithKeys { get; set; }
    }
}
