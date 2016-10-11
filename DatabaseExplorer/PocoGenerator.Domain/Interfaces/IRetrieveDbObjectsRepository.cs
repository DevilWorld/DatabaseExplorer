using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IRetrieveDbObjectsRepository
    {
        IEnumerable<TablesWithColumnsDto> GetTables();
        IEnumerable<TablesWithColumnsDto> GetViews();
        IEnumerable<TablesWithColumnsDto> GetStoredProcedures();
        IEnumerable<TablesWithColumnsDto> GetTableValuedFunctions();        
    }
}
