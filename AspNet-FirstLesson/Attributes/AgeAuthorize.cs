using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Attributes
{
    public class AgeAuthorize : AuthorizeAttribute
    {
        public int Age { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var claims = httpContext.User.Identity as ClaimsIdentity;
                var claim = claims.Claims.Where(c => c.Type == ClaimTypes.DateOfBirth).Select(c => c.Value).SingleOrDefault();
                DateTime userBirthDate = DateTime.Parse(claim);
                int userAge = (int)((DateTime.Now - userBirthDate).TotalDays / 365);
                if (Age <= userAge)
                {
                    return true;
                }
            }
            return false;
        }
    }
}