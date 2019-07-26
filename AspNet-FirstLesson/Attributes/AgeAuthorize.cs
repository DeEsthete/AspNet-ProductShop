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
            var claims = httpContext.User.Identity as ClaimsIdentity;
            var claim = claims.Claims.First(c => c.ValueType == ClaimTypes.DateOfBirth);
            DateTime userBirthDate = DateTime.Parse(claim.Value);
            int userAge = int.Parse(((DateTime.Now - userBirthDate).TotalDays / 365).ToString());
            if (Age == userAge)
            {
                return true;
            }
            return false;
        }
    }
}