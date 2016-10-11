using PocoGenerator.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IBlankSpaceService<T> 
                where T :class
    {
        //bool IsNameSpaceEnabled { get; set; }
        string ApplyBlankSpace(bool IsNameSpaceEnabled);
    }
}
