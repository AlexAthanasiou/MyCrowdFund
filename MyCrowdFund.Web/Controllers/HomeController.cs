using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyCrowdFund.Web.Controllers {

    public class HomeController : Controller {

        private readonly MyCrowdFundDbContext context_;
        private readonly IProjectService psvc_;

        public HomeController( 
            IProjectService psvc, MyCrowdFundDbContext context ) {
            context_ = context;
            psvc_ = psvc;
        }

        [HttpGet]
        public IActionResult Index(  ) {

            var list = TempData[ "pj" ] as string;

            if(list != null) {
                var x = JsonConvert.DeserializeObject<List<Project>>( list );

                var modelP = new ProjectViewModel() {
                    ProjectList = x
                };

                return PartialView( modelP );

            } else {

                var projectList = context_
                    .Set<Project>()
                    .OrderByDescending( k => k.FinancialProgress )
                    .ToList();

                var model = new ProjectViewModel() {

                    BestProjects = projectList.Take( 3 ).ToList(),
                    ProjectList = projectList
                };

                return View( model );
            }
        }

        [HttpGet( "home/ {id}" )]     
        public IActionResult Index(int id) {

            var projectList = context_
                .Set<Project>()              
                .OrderByDescending( k => k.FinancialProgress )              
                .ToList();
          
            var model = new ProjectViewModel() {

                BestProjects = projectList.Take(3).ToList(),
                ProjectList = projectList,
                UserId = id
            };
            
            return View(model);
        }

        [HttpGet]
        public IActionResult SearchProject() {

            var list = TempData[ "pj" ] as string;
            var x = JsonConvert.DeserializeObject<List<Project>>( list );

            var model = new ProjectViewModel() {
                ProjectList = x
            };

            return View( "SearchProject", model );
        }

        [HttpPost]
        public IActionResult SearchProject( /*[FromBody] SearchViewModel objectName*/ string objectName ) {

            var projectOptions = new SearchProjectOptions() {
                Title = objectName
            };

            var mod = psvc_.SearchProject( projectOptions ).ToList();
            var json = JsonConvert.SerializeObject( mod, Formatting.Indented );
            TempData[ "pj" ] = json;

            return RedirectToAction( "SearchProject", "Home" );
        }

        public IActionResult Privacy() {
            return View();
        }
        
        [HttpGet]
        public IActionResult Projects() {

            var query = context_
                  .Set<Project>()
                  .ToList();

            var projView = new ProjectViewModel() {
                ProjectList = query
            };
          
            return View(projView);
        }

        [HttpGet]
        public IActionResult Some() {

            return View();
        }

        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error() {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}
