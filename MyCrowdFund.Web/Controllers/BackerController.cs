using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;
using MyCrowdFund.Model;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using MyCrowdFund.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Controllers {
    public class BackerController : Controller
    {
        private readonly IBackerService bsvc_;
        private readonly MyCrowdFundDbContext context_;
        private readonly IProjectService psvc_;

        public BackerController( 
            IBackerService bsvc,
            IProjectService psvc, MyCrowdFundDbContext context ) {

            bsvc_ = bsvc;
            context_ = context;
            psvc_ = psvc;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet( "project/{backerId}" )]
        public IActionResult Profile( int backerId ) {

            var backer = context_
                .Set<Backer>()
                .Where( p => p.Id == backerId )
                .SingleOrDefault();

            var model = new BackerViewModel() {
                Backer = backer
            };

            return View( model );

        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateBackerOptions options) {

            var backer = await bsvc_.CreateBackerAsync( options ); //to onoma options na allaksw sto model

            return backer.AsStatusResult();
        }

        [HttpGet ("backer/{id}")]
        [Authorize( Roles ="Backer")]
        public async Task<IActionResult> BrowseMyProjects(int id) {            

            var backProj = context_
                .Set<BackerProject>()
                .Where( bp => bp.BackerId == id )
                .ToList();

            var projList = new List<Project>();

            foreach(var bp in backProj) {

                var proj = await psvc_.SearchProjectByIdAsync( bp.ProjectId );
                projList.Add( proj.Data );

            }
           
            var model = new BackerViewModel(){
                MyProjects = projList
            };

            return View( model );

        }     
    }
}