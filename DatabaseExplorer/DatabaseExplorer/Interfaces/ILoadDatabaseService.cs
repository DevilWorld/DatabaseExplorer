using PocoGenerator.Domain.Models.Dto;
using System.Collections.Generic;

namespace DatabaseExplorer.Interfaces
{
    public interface ILoadDatabaseService
    {
        IEnumerable<TablesWithColumnsDto> LoadTables();
    }
}
