using MyCrowdFund.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace MyCrowdFund
{
    public class ProjectCreator { 
 
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Project> MyProjects { get; set; }

        public ICollection<Reward> MyRewards { get; set; }

        public ProjectCreator() {

            MyProjects = new List<Project>();
            MyRewards = new List<Reward>();
        }


    }
}
