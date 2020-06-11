using Autofac;
using MyCrowdFund.Data;
using System;

namespace MyCrowdFund.Test {
    public  class MyCrowdFundFixture : IDisposable 
    {
        public MyCrowdFundDbContext DbContext { get; private set; }

        public ILifetimeScope Container { get; private set; }

        public MyCrowdFundFixture() {

            Container = ServiceRegistrator
                .GetContainer()
                .BeginLifetimeScope();
            DbContext = Container.Resolve<MyCrowdFundDbContext>();
        }

        public void Dispose() {

            Container.Dispose();
        }
    }
}
