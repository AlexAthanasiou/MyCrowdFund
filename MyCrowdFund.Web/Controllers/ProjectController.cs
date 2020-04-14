using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using MyCrowdFund.Web.Models;

namespace MyCrowdFund.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService psvc_;

        private readonly IRewardService rsvc_;

        public ProjectController( IProjectService psvc, IRewardService rsvc) {

            psvc_ = psvc;
            rsvc_ = rsvc;
            
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
        public async Task<IActionResult> Create(
            [FromBody] ProjectViewModel options, int creatorId ) {

            var project = await psvc_.CreateProjectAsync( creatorId, options.Options );

            var searchOptions = new SearchProjectOptions() {
                Title = project.Data.Title
            };

            var searchPr = psvc_.SearchProject( searchOptions ).SingleOrDefault();

            var reward = await rsvc_.CreateRewardAsync( creatorId, searchPr.Id, options.RewardOptions );



            return project.AsStatusResult();
            
        }

       
    }
}