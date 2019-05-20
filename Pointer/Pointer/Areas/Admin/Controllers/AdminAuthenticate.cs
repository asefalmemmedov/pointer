using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
namespace Pointer.Areas.Admin.Controllers
{
    public class AdminAuthenticate : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
          
        }
    }
}