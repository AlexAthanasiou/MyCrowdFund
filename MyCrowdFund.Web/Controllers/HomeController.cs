using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Models;

namespace MyCrowdFund.Web.Controllers {

    
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;
        private readonly MyCrowdFundDbContext context_;
        private readonly IProjectService psvc_;

        public HomeController( ILogger<HomeController> logger,
            IProjectService psvc, MyCrowdFundDbContext context ) {
            _logger = logger;
            context_ = context;
            psvc_ = psvc;
        }

        [HttpGet]
        public IActionResult Index(  ) {


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



        [HttpGet ("home/ {id}")]     
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

        //[HttpPost]
        //public IActionResult Index([FromBody] ProjectViewModel model) {

        //    var options = new SearchProjectOptions() {
        //        Title = model.Title
        //    };

        //    var projects = psvc_.SearchProject( options ).ToList();



        //    var model1 = new ProjectViewModel() {
        //        ProjectList = projects
        //    };



        //    return View("SearchProject", model1 );


        //}

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


        //[HttpPost]
        //public IActionResult SearchProject( [FromBody] ProjectViewModel model ) {

        //    var options = new SearchProjectOptions() {
        //        Title = model.Title
        //    };

        //    var projects = psvc_.SearchProject( options ).ToList();



        //    var model1 = new ProjectViewModel() {
        //        ProjectList = projects
        //    };



        //    return View( model1 );
        //}


        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error() {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}
