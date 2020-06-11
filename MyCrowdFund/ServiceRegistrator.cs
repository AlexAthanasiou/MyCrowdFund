using Autofac;
using MyCrowdFund.Data;
using MyCrowdFund.Services;
using System;

namespace MyCrowdFund {
    public class ServiceRegistrator : Module
  {
        public static void RegisterServices( ContainerBuilder builder) {

            if ( builder == null )
                throw new ArgumentNullException( nameof( builder ) );

            builder
                .RegisterType<MyCrowdFundDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();

            builder
                .RegisterType<BackerService>()
                .InstancePerLifetimeScope()
                .As<IBackerService>();

            builder
                .RegisterType<ProjectCreatorService>()
                .InstancePerLifetimeScope()
                .As<IProjectCreatorService>();

            builder
                .RegisterType<ProjectService>()
                .InstancePerLifetimeScope()
                .As<IProjectService>();

            builder
                .RegisterType<RewardService>()
                .InstancePerLifetimeScope()
                .As<IRewardService>();

            builder
                .RegisterType<LoggerService>()
                .InstancePerLifetimeScope()
                .As<ILoggerService>();
        }

        public static IContainer GetContainer() {

            var builder = new ContainerBuilder();
            RegisterServices( builder );

            return builder.Build();
        }

        protected override void Load( ContainerBuilder builder ) {
            RegisterServices( builder );
        }
    }
}
