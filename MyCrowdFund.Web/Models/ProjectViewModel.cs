using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Models {
    public class ProjectViewModel {

        public CreateProjectOptions Options { get; set; }

        public CreateRewardOptions RewardOptions { get; set; }
    }
}
