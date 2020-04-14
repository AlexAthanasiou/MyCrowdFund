using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrowdFund.Model {
    public class Reward {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProjectCreator RewardCreator { get; set; }

        public int RewardCreatorId { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

       

    }
}
