using Autofac;
using MyCrowdFund.Options;
using MyCrowdFund.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MyCrowdFund.Test {
   public class ProjectCreatorTests_SearchProjectCreator : IClassFixture<MyCrowdFundFixture>
    {
        private readonly IProjectCreatorService psvc_;

        public ProjectCreatorTests_SearchProjectCreator(MyCrowdFundFixture fixture) {

            psvc_ = fixture.Container.Resolve<IProjectCreatorService>();               
        }

        [Fact]
        public void SearchProjectCreator_Success() {

            var options = new SearchProjectCreatorOptions()
            {
                //Firstname = "Alex",
                //Lastname = "Athanasiou",
                Email = "alex@hotmail.gr"
            };

            var search = psvc_
                .SearchProjectCreator( options )
                .ToList();

            Assert.NotNull( search );          
        }

        [Fact]
        public void SearchProjectCreator_Fail() {

            var options = new SearchProjectCreatorOptions()
            {              
                Email = "george@hotmail.gr"
            };

            var search = psvc_
                .SearchProjectCreator( options )
                .SingleOrDefault();

            Assert.Null( search );
        }
    }
}
