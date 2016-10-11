using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces.Templates
{
    public interface ITemplate<T, TU> where T : class where TU :class
    {
        //Retrieves template at all levels of the object
        Template GetTemplate();
    }
}
