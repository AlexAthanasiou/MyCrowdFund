using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;
using MyCrowdFund.Model;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using MyCrowdFund.Web.Models;

namespace MyCrowdFund.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService psvc_;
        private readonly MyCrowdFundDbContext context_;
        private readonly IRewardService rsvc_;

        public ProjectController( IProjectService psvc,
            MyCrowdFundDbContext context, IRewardService rsvc ) {

            psvc_ = psvc;
            context_ = context;
            rsvc_ = rsvc;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet("project/ {id}")]
        [Authorize( Roles = "ProjectCreator" )]
        public IActionResult Create(int id) {

            var mod = new ProjectViewModel() {
                UserId = id
            };
            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           [FromBody]  ProjectViewModel op ) { // int creatorId

            //var options = new CreateProjectOptions() {
            //    Title = op.Title,
            //    Description = op.Description,
            //    Cost = op.Cost,
            //    Photo = op.Photo,
            //    Category = op.Cat


            //};

            var project = await psvc_.CreateProjectAsync( op.UserId, op.Model );

            //return RedirectToAction( "Create", "Reward" );

            return project.AsStatusResult();

        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> ProjectDetails(int id) {

            var tempProject = await psvc_.SearchProjectByIdAsync( id );
            var progress = (tempProject.Data.FinancialProgress /
                tempProject.Data.Cost) * 100;

             var progres =(int) Math.Truncate(progress);

            var rewards = context_.Set<Reward>()
                .Where( r => r.ProjectId == id )
                .ToList();

            var tempModel = new ProjectViewModel() {

                Proj = tempProject.Data,
                RewardList = rewards,
                Prog = progres
                
            };

            return View( tempModel );
        }

        [HttpPost]
        [Authorize( Roles = "Backer" )]
        public async Task<IActionResult> BuyProject([FromBody] BuyProjectModel rewardId) {

            var rew = context_.Set<Reward>()
                .Where( r => r.Id == rewardId.RewardId )
                .SingleOrDefault();

            var tempProj = await psvc_.BuyProjectAsync( rew.ProjectId, 1, rewardId.RewardId );

            return tempProj.AsStatusResult();

        }

      
        [HttpGet( "Home/{category}" )]
        public IActionResult BrowseByCategory(ProjectCategory category) {


            var options = new SearchProjectOptions() {

                Category = category
            };

            var projects = psvc_.SearchProject( options );

         var pList =  projects.Take( 500 ).ToList();

            var model = new ProjectViewModel() {
                ProjectList = pList
            };

            return View( model);

        }









    }



}