using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Services.BlankSpace
{
    public class ClassBlankSpaceService: IBlankSpaceService<ClassBlankSpaceService>
    {
        //public bool IsNameSpaceEnabled { get; set; }
        public string ApplyBlankSpace(bool IsNameSpaceEnabled)
        {
            if (IsNameSpaceEnabled)
                return "&nbsp&nbsp&nbsp&nbsp";
            //return "\t";
            else
                return string.Empty;
        }
    }
}
