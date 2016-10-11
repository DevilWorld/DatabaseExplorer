using System;
using System.Collections.Generic;
using System.Linq;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator.Domain.Interfaces.Templates
{
    public interface IGenerateTemplate
    {
        //Generate templates at the higher level
        string Generate(TemplateType templateType, TablesWithColumnsDto tableWithColumns);
    }
}
