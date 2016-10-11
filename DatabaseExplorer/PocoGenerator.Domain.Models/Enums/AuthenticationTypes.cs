using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.Enums
{
    public enum AuthenticationTypes
    {
        [Description("Windows Authentication")]
        WindowsAuthentication,
        [Description("SQL Server Authentication")]
        SQLServerAuthentication
    }
}
