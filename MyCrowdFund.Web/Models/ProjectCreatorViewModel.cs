using MyCrowdFund.Options;
using System.Collections.Generic;

namespace MyCrowdFund.Web.Models {
    public class ProjectCreatorViewModel {

        public ProjectCreator Creator { get; set; }

        public ProjectCreatorOptions options { get; set; }

        public UpdateProjectCreatorOptions Ops { get; set; }

        public List<Project> MyProjects { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }
    }
}
