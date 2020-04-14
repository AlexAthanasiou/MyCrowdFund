using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using MyCrowdFund.Web.Models;

namespace MyCrowdFund.Web.Controllers
{
    public class ProjectCreatorController : Controller
    {
        private readonly IProjectCreatorService csvc_;
        private readonly MyCrowdFundDbContext context_;

        public ProjectCreatorController(IProjectCreatorService csvc, MyCrowdFundDbContext context) {

            csvc_ = csvc;
            context_ = context;
                
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {
           
            return View();
          
        }


        [HttpPost]
        public async Task<IActionResult> CreateOwner(
            [FromBody] ProjectCreatorOptions options ) {

            var creator = await csvc_.NewProjectCretorAsync( options );

            return creator.AsStatusResult();
        }
    }
}