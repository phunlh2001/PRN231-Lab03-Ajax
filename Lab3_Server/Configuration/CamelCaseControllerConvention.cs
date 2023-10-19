using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace Lab3_Server.Configuration
{
    public class CamelCaseControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName =
                Char.ToLowerInvariant(controller.ControllerName[0]) + controller.ControllerName.Substring(1);
        }
    }
}
