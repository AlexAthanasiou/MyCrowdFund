using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Controllers {
    public class RewardController : Controller
    {
        private readonly IRewardService rsvc_;

        public RewardController( IRewardService rsvc) {

            rsvc_ = rsvc;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet( "reward/{id}/{creatorId}" )]
        [Authorize( Roles = "ProjectCreator" )]
        public IActionResult Create(int id, int creatorId) {
        
            var mod = new CreateRewardOptions() {
                TempId = id
            };

            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Create( 
            [FromBody] CreateRewardOptions options) {

            return( await rsvc_.CreateRewardAsync( options.CreatorId, options.TempId , options )).AsStatusResult();         
        }
    }
}