using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Interfaces.Templates;

namespace PocoGenerator.Domain.Services.Output
{
    public class RenderOutputUsingTablesWithColumnsService : IRenderOutputStrategy<TablesWithColumnsDto>
    {
        private readonly IGenerateTemplate _generateTemplate;

        public RenderOutputUsingTablesWithColumnsService(IGenerateTemplate generateTemplate)
        {
            _generateTemplate = generateTemplate;
            
        }

        public string RenderOutput(TablesWithColumnsDto tableWithColumnsDto)
        {
            var templateType = Global.IsNameSpaceEnabled ? TemplateType.Namespace : TemplateType.Class;

            var result = string.Empty;
            
            if (tableWithColumnsDto != null)
                result += _generateTemplate.Generate(templateType, tableWithColumnsDto);

            return result;
        }
    }
}
