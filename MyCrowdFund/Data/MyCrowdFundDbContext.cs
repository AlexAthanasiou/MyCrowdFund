using Microsoft.EntityFrameworkCore;
using MyCrowdFund.Model;

namespace MyCrowdFund.Data {
    public class MyCrowdFundDbContext : DbContext
    {

        private readonly string connectionString_;

        public MyCrowdFundDbContext() : base()
        {
            connectionString_ = @"Server=localhost;Database=crowdfund;User Id=sa; Password=QWE123!@#";
        }

        public MyCrowdFundDbContext(string connString)
        {
            connectionString_ = connString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectCreator>()
                .ToTable("ProjectCreator");
                                

            modelBuilder.Entity<Backer>()
                .ToTable("Backer");

            modelBuilder.Entity<Project>()
                .ToTable("Project");

            modelBuilder.Entity<Project>()
               .HasOne<ProjectCreator>(c => c.Creator)
               .WithMany(p => p.MyProjects)
               .HasForeignKey(k => k.CreatorId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BackerProject>()
                .ToTable( "BackerProject" );
                
             //   .HasKey(bp => new { bp.BackerId, bp.ProjectId });

           

            modelBuilder.Entity<Reward>()
                 .ToTable( "Reward" );

            modelBuilder.Entity<Reward>()
                .HasOne<ProjectCreator>(c => c.RewardCreator)
                .WithMany(r => r.MyRewards)
                .HasForeignKey(k => k.RewardCreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reward>()
                .HasOne<Project>( p => p.Project )
                .WithMany( r => r.ProjectRewards )
                .HasForeignKey( k => k.ProjectId )
                .OnDelete( DeleteBehavior.Cascade );



            modelBuilder.Entity<BackerReward>()
                .ToTable( "BackerReward" );
               // .HasKey( br => new { br.RewardId, br.BackerId } );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer(connectionString_);
        }



    }
}
