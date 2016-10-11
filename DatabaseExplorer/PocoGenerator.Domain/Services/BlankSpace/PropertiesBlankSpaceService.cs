using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Services.BlankSpace
{
    public class PropertiesBlankSpaceService : IBlankSpaceService<PropertiesBlankSpaceService>
    {
        public string ApplyBlankSpace(bool IsNameSpaceEnabled)
        {
            if (IsNameSpaceEnabled)//configuring blank pscae for properties
                return "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";//return "\t\t";
            else
                return "&nbsp&nbsp&nbsp&nbsp";//return "\t";
        }
    }
}
