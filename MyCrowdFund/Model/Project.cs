using MyCrowdFund.Model;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyCrowdFund
{
    public class Project
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string Photo { get; set; }

        public ProjectCategory Category { get; set; }

        public decimal FinancialProgress { get; set; }
        
        public ICollection<Reward> ProjectRewards { get; set; }

        public ProjectCreator Creator { get; set; }

        public int CreatorId { get; set; }

        public ICollection<BackerProject> BackerList { get; set; }

      

        public Project() {

            ProjectRewards = new List<Reward>();
            BackerList = new List<BackerProject>();
        }






    }
}