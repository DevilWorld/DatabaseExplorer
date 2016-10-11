using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static string GetAuthenticationTypesDescription(this AuthenticationTypes e)
        {
            switch(e)
            {
                case AuthenticationTypes.WindowsAuthentication:
                    return "Windows Authentication";                    
                case AuthenticationTypes.SQLServerAuthentication:
                    return "SQL Server Authentication";
                default:
                    return string.Empty;
            }
        }

        public static string GetDbObjectTypesDescription(this DbObjectTypes e)
        {
            switch(e)
            {
                case DbObjectTypes.Tables:
                    return "Tables";
                case DbObjectTypes.Views:
                    return "Views";
                case DbObjectTypes.StoredProcedures:
                    return "Stored Procedures";
                case DbObjectTypes.TableValuedFunctions:
                    return "Table Valued Functions";
                default:
                    return string.Empty;
            }
        }
    }
}
