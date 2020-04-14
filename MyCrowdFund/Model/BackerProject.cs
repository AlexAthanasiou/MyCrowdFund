using System.Collections.Generic;

namespace MyCrowdFund.Model {
    public class BackerProject {


        public int Id { get; set; }
        public int BackerId { get; set; }

        public Backer Backer { get; set; }


        public int ProjectId { get; set; }

        public Project Project { get; set; }


    }
}
