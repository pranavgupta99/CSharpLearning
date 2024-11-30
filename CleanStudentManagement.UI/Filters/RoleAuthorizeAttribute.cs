using CleanStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.UI.Filters
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int _role;

        public RoleAuthorizeAttribute(int role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionObj = context.HttpContext.Session.GetString("loginDetails");
            if (string.IsNullOrEmpty(sessionObj))
            {
                context.Result = new RedirectToActionResult("Login", "Accounts", null);
                return;
            }
            var loginDetails = JsonConvert.DeserializeObject<LoginViewModel>(sessionObj);
            if (loginDetails.Role != _role)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
