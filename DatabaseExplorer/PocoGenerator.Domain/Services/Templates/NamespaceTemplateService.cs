using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace PocoGenerator.Domain.Services.Templates
{
    public class NamespaceTemplateService : ITemplate<SysObjects, NamespaceTemplateService>
    {
        //private readonly ITemplate<SysObjects, ClassTemplateService> _classTemplateService;

        //public NamespaceTemplateService(ITemplate<SysObjects, ClassTemplateService> classTemplateService)
        //{
        //    _classTemplateService = classTemplateService;
        //}

        public Template GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();

            //sbTemplate.Append("namespace ");
            //sbTemplate.AppendLine();
            //sbTemplate.Append("{");
            //sbTemplate.AppendLine();            
            //sbTemplate.Append("{{class}}");
            //sbTemplate.AppendLine();
            //sbTemplate.Append("}");

            sbTemplate.Append(string.Format("<font face={0} size='{1}'>", PocoConstants.Font, PocoConstants.FontSize));
            sbTemplate.Append(string.Format("<font color = '{0}'>namespace </font>", PocoConstants.ColorForKeyword));
            sbTemplate.Append("</br>");
            sbTemplate.Append(string.Format("<font color = '{0}'>{{</font>", PocoConstants.ColorForVariableName));
            sbTemplate.Append("</br>");
            sbTemplate.Append("{{class}}");
            sbTemplate.Append("</br>");
            sbTemplate.Append(string.Format("<font color = '{0}'>}}</font>", PocoConstants.ColorForVariableName));

            return Template.Parse(sbTemplate.ToString());
        }
    }
}
