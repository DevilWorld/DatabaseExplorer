using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.Dto
{
    public class ColumnsWithKeysDto
    {
        public string CONSTRAINT_CATALOG { get; set; }
        public string CONSTRAINT_SCHEMA { get; set; }
        public string CONSTRAINT_NAME { get; set; }
        public string TABLE_CATALOG { get; set; }
        public string TABLE_SCHEMA { get; set; }
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public int ORDINAL_POSITION { get; set; }
        public string KeyType { get; set; }
    }
}
