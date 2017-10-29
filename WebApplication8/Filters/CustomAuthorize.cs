using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication8.Filters
{
  public class CustomAuthorize : AuthorizeAttribute
  {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserID"] != null)
            {
            }
            else
            {

                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { Controller = "Account", Action = "Login" }));
                                //base.HandleUnauthorizedRequest(filterContext);
                                //maybe can redirect to another login page that give users hints to login.
            }


        }
  }

}