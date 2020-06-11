using MyCrowdFund.Model;
using System.Collections.Generic;

namespace MyCrowdFund.Options {
    public class CreateProjectOptions {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string Photo { get; set; }

        public ProjectCategory Category { get; set; }

        public ICollection<Reward> RewardList { get; set; }

        public CreateProjectOptions() {

            RewardList = new List<Reward>();
        }       
    }
}
