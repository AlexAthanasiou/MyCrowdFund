using Autofac;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyCrowdFund.Test {
    public  class BackerServiceTests : IClassFixture<MyCrowdFundFixture>
    {
        private readonly IBackerService bsvc_;

        public BackerServiceTests(MyCrowdFundFixture fixture) {

            bsvc_ = fixture.Container.Resolve<IBackerService>();
        }

        [Fact]
        public async Task CreateBacker_Success() {

            var options = new CreateBackerOptions()
            {
                Firstname = "Giotis",
                Lastname = "Athanasiou",
                Age = 30,
                Email = "giotis@gmail.gr",
                Photo = "somephoto"
            };

            var backer = await  bsvc_.CreateBackerAsync( options );
            Assert.NotNull( backer.Data );

            var search = bsvc_.SearchBacker( new SearchBackerOptions()
            {

                Email = backer.Data.Email
            } ).SingleOrDefault(b => b.Email == options.Email);

            Assert.NotNull( search );
            Assert.Equal( backer.Data.Firstname, search.Firstname );
            Assert.Equal( backer.Data.Lastname, search.Lastname );
            Assert.Equal( backer.Data.Age, search.Age );
            Assert.Equal( backer.Data.Email, search.Email );
            Assert.Equal( backer.Data.Photo, search.Photo );
        }
    }
}
