using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using MyCrowdFund.Web.Extensions;

namespace MyCrowdFund.Web.Controllers
{
    public class RewardController : Controller
    {
        private readonly IRewardService rsvc_;
        private readonly IProjectService psvc_;


        public RewardController( IRewardService rsvc, IProjectService psvc) {

            rsvc_ = rsvc;
            psvc_ = psvc;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet( "reward/{id}" )]
        [Authorize( Roles = "ProjectCreator" )]
        public IActionResult Create(int id) {

          

            var mod = new CreateRewardOptions() {
                TempId = id
            };



            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Create( 
            [FromBody] CreateRewardOptions options) {

            return( await rsvc_.CreateRewardAsync( 1, options.TempId , options )).AsStatusResult();
          
        }
    }
}