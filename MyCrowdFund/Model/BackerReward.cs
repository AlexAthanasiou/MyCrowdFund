using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrowdFund.Model {
 public  class BackerReward {

        public int Id { get; set; }

        public Backer Backer { get; set; }

        public int BackerId { get; set; }

        public Reward Reward { get; set; }

        public int RewardId { get; set; }
    }
}
