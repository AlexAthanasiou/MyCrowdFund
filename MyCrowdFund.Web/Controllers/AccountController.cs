using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;

namespace MyCrowdFund.Web.Controllers
{
    public class AccountController : Controller {

        private readonly MyCrowdFundDbContext context_;

        public AccountController( MyCrowdFundDbContext context) {

            context_ = context;
                
        }
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Login() {

            return View();

        }

        [HttpPost]
        public IActionResult Login(
            string userName, string password ) {

            ClaimsIdentity identity = null;
            int tempId = default;

            var isAuthenticated = false;

            if ( string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace( password )) {

                return RedirectToAction( "Login", "Account" );

            }

            var tempCreator = context_
                .Set<ProjectCreator>()
                .Where( c => c.Username == userName
                 && c.Password == password )
                .SingleOrDefault();

            var tempBacker = context_
                .Set<Backer>()
                .Where( c => c.Username == userName
                 && c.Password == password )
                .SingleOrDefault();

            //if ( tempCreator == null &&         
            //    tempBacker == null ) {
            //    return RedirectToAction( "Login", "Account" );
            //}

            if (tempCreator != null ) {

                if ( tempCreator.Username.Equals( userName )
                && tempCreator.Password.Equals( password ) ) {

                    identity = new ClaimsIdentity( new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "ProjectCreator")
                }, CookieAuthenticationDefaults.AuthenticationScheme );

                    isAuthenticated = true;

                    tempId = tempCreator.Id;
                }


            }

            if ( tempBacker != null) {


                if ( tempBacker.Username.Equals( userName )
                    && tempBacker.Password.Equals( password ) ) {

                    identity = new ClaimsIdentity( new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Backer")
                }, CookieAuthenticationDefaults.AuthenticationScheme );

                    isAuthenticated = true;
                    tempId = tempBacker.Id;
                }

            }

           


            if( isAuthenticated) {

            var principal = new ClaimsPrincipal( identity );

                var login = HttpContext.SignInAsync( 
                    CookieAuthenticationDefaults.AuthenticationScheme, principal );

                return RedirectToAction( "Index", "Home", new { id = tempId } );

            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout() {
            var login = HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme );

            return RedirectToAction( "Index", "Home" );
        }
    }
}