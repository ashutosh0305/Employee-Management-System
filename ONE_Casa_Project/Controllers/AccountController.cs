

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ONE_Casa_Project.Models;


namespace ONE_Casa_Project.Controllers
{
    public class AccountController : Controller
    {
        //[Route("Google-Login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        //[Route("Google-Response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim =>
                new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value

                });
            var email = claims.ToList().ElementAt(4).Value.Trim();
            var name = claims.ToList().ElementAt(1).Value.Trim();

            TempData["Email"] = email;
            TempData["Name"] = name;
            //data.ForEach(x => { });
            return RedirectToAction("Check", "Home");
        }
    }
}