using DatabaseExplorer.Interfaces;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Domain.Models.Enums;
using System.Collections.Generic;

namespace DatabaseExplorer.Services
{
    internal class LoadDatabaseService : ILoadDatabaseService
    {
        private readonly IRetrieveDbObjectsService _retrieveDbObjectService;

        public LoadDatabaseService(IRetrieveDbObjectsService retrieveDbObjectService)
        {
            _retrieveDbObjectService = retrieveDbObjectService;
        }

        public IEnumerable<TablesWithColumnsDto> LoadTables()
        {
            return _retrieveDbObjectService.GetDbObjects(DbObjectTypes.Tables);
        }
    }
}
