using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using MyCrowdFund.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Controllers {
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

        [HttpGet("projectCreator/{creatorId}")]
        public IActionResult Profile(int creatorId) {

            var creator = context_
                .Set<ProjectCreator>()
                .Where( p => p.Id == creatorId )
                .SingleOrDefault();

            var model = new ProjectCreatorViewModel() {
                Creator = creator
            };

            return View( model );



        }    

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProjectCreatorOptions options ) {

            var creator = await csvc_.NewProjectCretorAsync( options );

            return creator.AsStatusResult();
        }

        [HttpGet ("projectCreator/ {id} ")]
        [Authorize( Roles = "ProjectCreator" )]
        public IActionResult BrowseMyProjects(int id) {

            var proj = context_
                .Set<Project>()
                .Where( p => p.CreatorId == id )
                .ToList();

            var model = new ProjectCreatorViewModel() {

                MyProjects = proj
            };

            return View( model );
        }
    }
}