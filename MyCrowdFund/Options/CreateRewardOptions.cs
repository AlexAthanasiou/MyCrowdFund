namespace MyCrowdFund.Options {
    public  class CreateRewardOptions {

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int TempId { get; set; }

        public int CreatorId { get; set; }     
    }
}
