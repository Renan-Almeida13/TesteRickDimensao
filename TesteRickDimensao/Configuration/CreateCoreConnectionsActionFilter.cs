﻿using Core.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteRickDimensao.Controllers.Base;

namespace TesteRickDimensao.Configuration
{
    public class CreateCoreConnectionsActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is LocalizacaoRickControllerBase controller)
            {
                controller.CreateCoreConnections();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
