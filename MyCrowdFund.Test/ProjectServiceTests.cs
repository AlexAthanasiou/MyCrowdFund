using Autofac;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyCrowdFund.Test {
   public class ProjectServiceTests : IClassFixture<MyCrowdFundFixture>
    {
        private readonly IProjectService psvc_;

        public ProjectServiceTests(MyCrowdFundFixture fixture) {

            psvc_ = fixture.Container.Resolve<IProjectService>();
        }

        [Fact]
        public async Task CreateProject_Success() {

            var options = new CreateProjectOptions()
            {
                Title = " New 5",
                Description = "Some Description",
                Cost = 1000.00M,
                Photo = " Some Photo ",
                Category = ProjectCategory.DesignAndTech,
                
            };

            var project = await psvc_.CreateProjectAsync(1, options );

            Assert.NotNull( project.Data );

            var search = psvc_.SearchProject( new SearchProjectOptions()
            {
                Title = "New Project "
            } ).ToList();

            Assert.NotNull( search);
          
        }

        [Fact]
        public async Task BuyProject_Success() {

            var isbought = await psvc_.BuyProjectAsync( 2, 1, 6 );

            Assert.NotNull( isbought );
        }

    }
}
