using Autofac;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyCrowdFund.Test {
  public  class RewardServiceTests : IClassFixture<MyCrowdFundFixture>
    {
        private readonly IRewardService rsvc_;

        public RewardServiceTests(MyCrowdFundFixture fixture) {

            rsvc_ = fixture.Container.Resolve<IRewardService>();
        }

        [Fact]
        public async Task CreateReward_Success() {

            var options = new CreateRewardOptions()
            {
                Title = "Reward 2",
                Description = " some desc ",
                Price = 1500.00M
            };

            var isCreated = await  rsvc_.CreateRewardAsync( 1, 1, options );

            Assert.NotNull( isCreated.Data );
        }


    }
}
