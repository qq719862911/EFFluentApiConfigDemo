using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp22
{
    public class CheckAuthorFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            if (actionName != "Home") { }
            //{
            //    filterContext.Result = new ContentResult() { Content = "Error" };
            //}
        }
    }
}