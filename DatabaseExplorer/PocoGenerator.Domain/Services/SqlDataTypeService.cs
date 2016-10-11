using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PocoGenerator.Domain.Interfaces;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator.Domain.Services
{
    public class SqlDataTypeService : IDataTypeService
    {
        public IEnumerable<string> GetAllDotNetDataTypes()
        {
            var lstDotNetDataTypes = new List<string>();

            lstDotNetDataTypes.Add("Int16");
            lstDotNetDataTypes.Add("Int32");
            lstDotNetDataTypes.Add("Int64");
            lstDotNetDataTypes.Add("string");
            lstDotNetDataTypes.Add("byte");
            lstDotNetDataTypes.Add("byte[]");
            lstDotNetDataTypes.Add("bool");
            lstDotNetDataTypes.Add("DateTime");
            lstDotNetDataTypes.Add("DateTimeOffset");
            lstDotNetDataTypes.Add("decimal");
            lstDotNetDataTypes.Add("TimeSpan");
            lstDotNetDataTypes.Add("Guid");
            lstDotNetDataTypes.Add("double");

            return lstDotNetDataTypes;
        }

        public IEnumerable<string> GetAllDbDataTypes()
        {
            var lstSqlDataTypes = new List<string>();

            lstSqlDataTypes.Add("bigint");
            lstSqlDataTypes.Add("binary");
            lstSqlDataTypes.Add("bit");
            lstSqlDataTypes.Add("char");
            lstSqlDataTypes.Add("date");
            lstSqlDataTypes.Add("datetime");
            lstSqlDataTypes.Add("datetime2");
            lstSqlDataTypes.Add("DateTimeOffset");
            lstSqlDataTypes.Add("decimal");
            lstSqlDataTypes.Add("float");
            lstSqlDataTypes.Add("image");
            lstSqlDataTypes.Add("int");
            lstSqlDataTypes.Add("money");
            lstSqlDataTypes.Add("nchar");
            lstSqlDataTypes.Add("ntext");
            lstSqlDataTypes.Add("numeric");
            lstSqlDataTypes.Add("nvarchar");
            lstSqlDataTypes.Add("rowversion");
            lstSqlDataTypes.Add("smallint");
            lstSqlDataTypes.Add("smallmoney");
            lstSqlDataTypes.Add("time");
            lstSqlDataTypes.Add("tinyint");
            lstSqlDataTypes.Add("uniqueidentifier");
            lstSqlDataTypes.Add("varbinary");
            lstSqlDataTypes.Add("varchar");

            return lstSqlDataTypes;
        }

        public string GetEquivalentNetCLRType(string strSqlDataType)
        {
            return this.GetDataTypeMappings()[strSqlDataType];
        }

        public IEnumerable<DataTypeDto> GetGridDatasource()
        {
            var mappings = new List<DataTypeDto>();

            foreach (var map in GetDataTypeMappings())
            {
                mappings.Add(new DataTypeDto() { DbDataTypeName = map.Key, DotNetDataTypeName = map.Value });
            }

            return mappings;
        }

        public IDictionary<string, string> GetDataTypeMappings()
        {
            Dictionary<string, string> dataTypeMappings = new Dictionary<string, string>
            {
                {"bigint", "Int64" },
                {"binary", "byte[]" },
                {"bit", "bool" },
                {"char", "string" },
                {"date", "DateTime" },
                {"datetime", "DateTime" },
                {"datetime2", "DateTime" },
                {"DateTimeOffset", "DateTimeOffset" },
                {"decimal", "decimal" },
                {"float", "double" },
                {"image", "" },
                {"int", "Int32" },
                {"money", "decimal" },
                {"nchar", "string" },
                {"ntext", "string" },
                {"numeric", "decimal" },
                {"nvarchar", "string" },
                {"rowversion", "byte[]" },
                {"smallint", "Int16" },
                {"smallmoney", "decimal" },
                {"time", "TimeSpan" },
                {"tinyint", "byte" },
                {"uniqueidentifier", "Guid" },
                {"varbinary", "byte[]" },
                {"varchar", "string" }
            };

            return dataTypeMappings;
        }
    }
}
