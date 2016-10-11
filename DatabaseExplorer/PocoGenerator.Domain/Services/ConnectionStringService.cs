using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using PocoGenerator.Domain;

namespace PocoGenerator.Domain.Services
{
    public class ConnectionStringService : IConnectionStringService
    {
        public string BuildConnectionString(ConnectionStringProperties connectionStringProperties, bool blnPartialConnectionString = false)
        {
            var settings = ConfigurationManager.ConnectionStrings["sqlConnectionString"];

            if (settings != null)
            {
                var connectString = settings.ConnectionString;

                var builder = new SqlConnectionStringBuilder(connectString);

                builder.DataSource = connectionStringProperties.DataSource;

                if (blnPartialConnectionString)
                    builder.InitialCatalog = connectionStringProperties.InitialCatalog;

                if (connectionStringProperties.AuthenticationType == Models.Enums.AuthenticationTypes.SQLServerAuthentication)
                {
                    builder.UserID = connectionStringProperties.UserId;
                    builder.Password = connectionStringProperties.Password;
                }
                else
                {
                    builder.IntegratedSecurity = true;
                }

                builder.MultipleActiveResultSets = true;
                
                Global.ConnectionString = builder.ConnectionString;

                return builder.ConnectionString;
            }

            return string.Empty;
        }

        public string GetConnectionString()
        {
            return Global.ConnectionString;
        }
    }
}
