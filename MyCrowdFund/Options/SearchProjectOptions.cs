using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrowdFund.Options {
  public  class SearchProjectOptions {

     public int Id { get; set; }

     public string Title { get; set; }

     public ProjectCategory Category { get; set; }
  }
}
