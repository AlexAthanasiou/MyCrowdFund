using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyCrowdFund.Model {
    public class BackerProject {

       
        public int Id { get; set; }
        
        public int BackerId { get; set; }
        [JsonIgnore]
        public Backer Backer { get; set; }

       
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }


    }
}
