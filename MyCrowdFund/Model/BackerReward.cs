using System.Text.Json.Serialization;

namespace MyCrowdFund.Model {
    public  class BackerReward {

        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public Backer Backer { get; set; }

        public int BackerId { get; set; }

        [JsonIgnore]
        public Reward Reward { get; set; }

        [JsonIgnore]
        public int RewardId { get; set; }
    }
}
