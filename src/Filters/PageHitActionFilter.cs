using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Filters
{
    public class PageHitActionFilter : ActionFilterAttribute
    {
        private readonly IStatisticsDataRepository statisticsDataRepository;

        public PageHitActionFilter(IStatisticsDataRepository statisticsDataRepository)
        {
            this.statisticsDataRepository = statisticsDataRepository;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var controller = context.Controller.ToString();
            var action = context.ActionDescriptor.DisplayName;
            action = action?
                .Substring(action.LastIndexOf('.') + 1, action.LastIndexOf(' ') - action.LastIndexOf('.') - 1);
            controller = controller?
                .Substring(controller.LastIndexOf('.') + 1);
            statisticsDataRepository.AddHit(controller, action);
        }
    }
}
