using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IDbConnectService
    {
        void Connect(string strConnectionString);
        bool TestConnection(string strConnectionString);

        IEnumerable<DatabaseName> GetDatabases();
    }
}
