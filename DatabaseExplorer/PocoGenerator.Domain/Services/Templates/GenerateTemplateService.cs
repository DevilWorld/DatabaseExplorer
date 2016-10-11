using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.DotLiquidDrops;
//using PocoGenerator.Common;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Domain.ExtensionMethods;

namespace PocoGenerator.Domain.Services.Templates
{
    public class GenerateTemplateService : IGenerateTemplate
    {
        //private readonly ITemplate<SysObjects> _template;
        

        public GenerateTemplateService(/*ITemplate<SysObjects> template*/)
        {
            //_template = template;            
        }        

        public string Generate(TemplateType templateType, TablesWithColumnsDto tableWithColumns)
        {
            switch (templateType)
            {
                case TemplateType.Namespace:
                    {
                        if (tableWithColumns != null)
                        {
                            var template = Global.TemplateManager[TemplateType.Namespace];
                            var result =
                                    template.Render(
                                    Hash.FromAnonymousObject(new
                                    {
                                        @class = GetClass(tableWithColumns)
                                    }));

                            return result;
                        }

                        break;
                    }

                case TemplateType.Class:
                    {
                        if (tableWithColumns != null)
                        {
                            return GetClass(tableWithColumns);
                        }
                        break;
                    }
                default:
                    {
                        var template = Global.TemplateManager[TemplateType.Class];
                        break;
                    }
            }

            return string.Empty;
        }

        private string GetClass(TablesWithColumnsDto tableWithColumns)
        {
            var template = Global.TemplateManager[TemplateType.Class];
            var sysObjects = tableWithColumns.MapToModel<SysObjects>();

            var result =
                template.Render(
                    Hash.FromAnonymousObject(new
                    {
                        table = new TableWithColumnsDrop(sysObjects),
                        columns = GetProperties(sysObjects) 
                    }
                                            )
                                );

            return result;            
        }

        /// <summary>
        /// Loop thru the columns and generate rhe properties
        /// </summary>
        /// <param name="sysColumns"></param>
        /// <returns></returns>
        private string GetProperties(SysObjects sysObjects)
        {
            var template = Global.TemplateManager[TemplateType.Properties];

            var sbProperty = new StringBuilder();

            sysObjects.Columns.ToList().ForEach(x =>
                {
                    sbProperty.Append( template.Render(Hash.FromAnonymousObject(new
                    {
                        column = new SysColumnsDrop(x)          //template in propertiestemplateservice
                    })));
                });

            return sbProperty.ToString();
        }
    }
}
