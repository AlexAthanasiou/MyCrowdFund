using Autofac;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyCrowdFund.Test {
    public class ProjectCreatorTests_NewProjectCreator : IClassFixture<MyCrowdFundFixture>         
    {
        private readonly IProjectCreatorService csvc_;

        public ProjectCreatorTests_NewProjectCreator( MyCrowdFundFixture fixture) {

            csvc_ = fixture.Container.Resolve<IProjectCreatorService>();               
        }

        [Fact]
        public async Task NewProjectCreator_Success() {

            var options = new ProjectCreatorOptions()
            {
                Firstname = "Panos",
                Lastname = "Athanasiou",
                Age = 27,
                Email = "panos@hotmail.gr",
                Photo = "photo3"

            };

            var creator = await csvc_.NewProjectCretorAsync( options );
            Assert.NotNull( creator.Data );

            var search = csvc_.SearchProjectCreator( new SearchProjectCreatorOptions()
            {
                Email = "panos@hotmail.gr"
            } ).SingleOrDefault( c => c.Email == options.Email );
             
            Assert.NotNull( search );
            Assert.Equal( creator.Data.Firstname, search.Firstname );
            Assert.Equal( creator.Data.Lastname, search.Lastname );
            Assert.Equal( creator.Data.Email, search.Email );
        }

        [Fact]
        public async Task NewProjectCreator_Fail() {

            var options = new ProjectCreatorOptions()
            {
                Lastname = "Athanasiou",
                Age = 27,
                Email = "sakis@hotmail.gr",
                Photo = "photo3"

            };

            var creator = await csvc_.NewProjectCretorAsync( options );
            Assert.Null( creator.Data );         
        }
    }
}
