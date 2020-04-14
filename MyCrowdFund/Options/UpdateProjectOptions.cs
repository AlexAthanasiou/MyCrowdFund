using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrowdFund.Options {
  public  class UpdateProjectOptions {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string Photo { get; set; }

        //gia tin wra auta alla
        //kalo einai na boroume na kanoume update/delete ta rewards 
    }
}
