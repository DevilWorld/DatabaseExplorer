using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IDataTypeService
    {
        string GetEquivalentNetCLRType(string strSqlDataType);
        IEnumerable<string> GetAllDotNetDataTypes();
        IEnumerable<string> GetAllDbDataTypes();
        IEnumerable<DataTypeDto> GetGridDatasource();

        IDictionary<string, string> GetDataTypeMappings();
    }
}
