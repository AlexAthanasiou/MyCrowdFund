using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System;
using System.Collections.Generic;

namespace MyCrowdFund.Web.Models {

    [Serializable]
    public class ProjectViewModel {

        public CreateProjectOptions Model { get; set; }

        public List<Project> ProjectList { get; set; }

        public List<Project> BestProjects { get; set; }

        public List<Reward> RewardList { get; set; }
        
        public Project Proj { get; set; }

        public List<ProjectCategory> Category { get; set; }

        public int UserId { get; set; }

        public int  Prog { get; set; }
    }
}
