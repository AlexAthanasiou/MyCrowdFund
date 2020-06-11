using MyCrowdFund.Options;
using System.Collections.Generic;

namespace MyCrowdFund.Web.Models {
    public class BackerViewModel {

        public CreateBackerOptions Options { get; set; }

        public Backer Backer { get; set; }

        public List<Project> MyProjects { get; set; }
    }
}
