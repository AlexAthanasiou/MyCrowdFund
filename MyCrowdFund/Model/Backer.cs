using MyCrowdFund.Model;
using System;
using System.Collections.Generic;

namespace MyCrowdFund {
    public class Backer { 
        
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<BackerProject> MyFundedProjects { get; set; }

        public ICollection<BackerReward> BackerRewards { get; set; }

        public Backer() {

            MyFundedProjects = new List<BackerProject>();
            BackerRewards = new List<BackerReward>();
        }
    }
}
