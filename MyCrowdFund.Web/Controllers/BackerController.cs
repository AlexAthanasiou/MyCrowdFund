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
    public class BackerController : Controller
    {
        private readonly IBackerService bsvc_;

        public BackerController( IBackerService bsvc) {

            bsvc_ = bsvc;
            
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
            [FromBody] BackerViewModel options) {

            var backer = await bsvc_.CreateBackerAsync( options.Options ); //to onoma options na allaksw sto model

            return backer.AsStatusResult();

        }

       
    }
}