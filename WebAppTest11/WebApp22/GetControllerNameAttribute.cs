using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp22
{
    public class GetControllerNameAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
         var des =   filterContext.ActionDescriptor.ControllerDescriptor;
           
            if (des.ControllerName != "Home")
            {
                filterContext.Result = new ContentResult() { Content = "Error" };
            }
        }

    }
}