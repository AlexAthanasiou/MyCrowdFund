using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Models {
    public class BackerViewModel {

        public CreateBackerOptions Options { get; set; }

        public List<Project> MyProjects { get; set; }
    }
}
