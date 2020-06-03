using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Web.Models {

    
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
