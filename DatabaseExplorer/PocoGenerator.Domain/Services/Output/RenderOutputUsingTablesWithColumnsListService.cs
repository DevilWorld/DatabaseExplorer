using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Services.Output
{
    public class RenderOutputUsingTablesWithColumnsListService: IRenderOutputStrategy<IEnumerable<TablesWithColumnsDto>>
    {
        private readonly IGenerateTemplate _generateTemplate;

        public RenderOutputUsingTablesWithColumnsListService(IGenerateTemplate generateTemplate)
        {
            _generateTemplate = generateTemplate;
        }
        public string RenderOutput(IEnumerable<TablesWithColumnsDto> tablesWithColumnsDto)
        {
            var templateType = Global.IsNameSpaceEnabled ? TemplateType.Namespace : TemplateType.Class;

            var result = string.Empty;

            if (tablesWithColumnsDto != null)
                tablesWithColumnsDto.ToList().ForEach(x => result += 
                                                        (string.IsNullOrEmpty(result) ? string.Empty : Environment.NewLine) + 
                                                        _generateTemplate.Generate(templateType, x));

            return result;
        }
    }
}
