using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IConnectionStringService
    {
        string BuildConnectionString(ConnectionStringProperties connectionStringProperties, bool blnPartialConnectionString = false);
        string GetConnectionString();
    }
}
