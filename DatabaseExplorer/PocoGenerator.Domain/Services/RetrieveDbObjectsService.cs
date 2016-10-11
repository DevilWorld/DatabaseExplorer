using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Services
{
    public class RetrieveDbObjectsService : IRetrieveDbObjectsService
    {
        private readonly IRetrieveDbObjectsRepository _retrieveDbObjectsRepository;

        public RetrieveDbObjectsService(IRetrieveDbObjectsRepository retrieveDbObjectsRepository)
        {
            _retrieveDbObjectsRepository = retrieveDbObjectsRepository;
        }

        public IEnumerable<TablesWithColumnsDto> GetDbObjects(DbObjectTypes dbObjectType)
        {
            switch(dbObjectType)
            {
                case DbObjectTypes.Tables:
                   return _retrieveDbObjectsRepository.GetTables();
                case DbObjectTypes.StoredProcedures:
                    return _retrieveDbObjectsRepository.GetStoredProcedures();
                case DbObjectTypes.Views:
                    return _retrieveDbObjectsRepository.GetViews();
                case DbObjectTypes.TableValuedFunctions:
                    return _retrieveDbObjectsRepository.GetTableValuedFunctions();
                default:
                    return new List<TablesWithColumnsDto>();
            }
        }
    }
}
