using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces.Templates;
using DotLiquid;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Services.BlankSpace;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Services.Templates
{
    public class ClassTemplateService : ITemplate<SysObjects, ClassTemplateService>
    {
        //private readonly ITemplate<SysColumns, PropertiesTemplateSevice> _propertiesTemplateService;
        IBlankSpaceService<ClassBlankSpaceService> _blankSpaceService;
        public ClassTemplateService(IBlankSpaceService<ClassBlankSpaceService> blankSpaceService)
        {
            _blankSpaceService = blankSpaceService;
        }

        public Template GetTemplate()       //Pass template type as a parameter based on the user selection.
                                            //Now it is hard-coded for development.
        {
            StringBuilder sbTemplate = new StringBuilder();
            //Add blank space manager logic
            //sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));      //TODO Remove template type from this ApplyBlankSpace(). We should hard-code template here bcoz this is class templates service
            //sbTemplate.Append("public class {{table.name}}");
            //sbTemplate.AppendLine();
            //sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));
            //sbTemplate.Append("{");
            //sbTemplate.AppendLine();
            //sbTemplate.Append("{{columns}}");
            //sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));
            //sbTemplate.Append("}");

            sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));      //TODO Remove template type from this ApplyBlankSpace(). We should hard-code template here bcoz this is class templates service
            sbTemplate.Append(string.Format("<font face={0} size='{1}'>", PocoConstants.Font, PocoConstants.FontSize));
            sbTemplate.Append(string.Format("<font color = '{0}'>public </font>", PocoConstants.ColorForKeyword));
            sbTemplate.Append(string.Format("<font color = '{0}'>class </font>", PocoConstants.ColorForKeyword));
            sbTemplate.Append(string.Format("<font color = '{0}'>{{{{table.name}}}}</font>", PocoConstants.ColorForVariableName));            
            sbTemplate.Append("</br>");
            sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));
            sbTemplate.Append(string.Format("<font color = '{0}'>{{</font>", PocoConstants.ColorForVariableName));
            sbTemplate.Append("</br>");
            sbTemplate.Append("{{columns}}");
            sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));
            sbTemplate.Append(string.Format("<font color = '{0}'>}}</font>", PocoConstants.ColorForVariableName));

            return Template.Parse(sbTemplate.ToString());
        }
    }
}
