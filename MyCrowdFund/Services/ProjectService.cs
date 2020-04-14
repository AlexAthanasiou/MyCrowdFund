using Microsoft.EntityFrameworkCore;
using MyCrowdFund.Data;
using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public  class ProjectService : IProjectService
        {

        private readonly MyCrowdFundDbContext context_;
        private readonly IProjectCreatorService csvc_;
        private readonly IBackerService bsvc_;
        private readonly IRewardService rsvc_;
        private readonly ILoggerService log_;

        public ProjectService(MyCrowdFundDbContext context, 
            IProjectCreatorService csvc, IBackerService bsvc, IRewardService rsvc, ILoggerService log  ) {

            context_ = context;
            csvc_ = csvc;
            bsvc_ = bsvc;
            rsvc_ = rsvc;
            log_ = log;
        }

        public async Task<ApiResult<Project>> CreateProjectAsync( int creatorId, 
            CreateProjectOptions CreateProjectOptions) {

            if ( CreateProjectOptions == null )
                return new ApiResult<Project>(StatusCode.BadRequest, " Null options " );

            if ( creatorId <= 0 )
                return new ApiResult<Project>(StatusCode.BadRequest, " Creator's Id is invalid " );

            if ( string.IsNullOrWhiteSpace( CreateProjectOptions.Title ) )
                return new ApiResult<Project>(StatusCode.BadRequest, " Title is null " );

            if ( string.IsNullOrWhiteSpace( CreateProjectOptions.Description ) )
                return new ApiResult<Project>( StatusCode.BadRequest, " Descriptions is null " );


            if ( CreateProjectOptions.Cost <= 0 )
                return new ApiResult<Project>(StatusCode.BadRequest, " Cost is null " );

            if ( string.IsNullOrWhiteSpace( CreateProjectOptions.Photo ) )
                return new ApiResult<Project>(StatusCode.BadRequest, " Photo's link is null " );

            if ( CreateProjectOptions.Category == 0 )
                return new ApiResult<Project>(StatusCode.BadRequest, " Category is invalid " );

            var exists = await SearchProject( new SearchProjectOptions()
            {
                Title = CreateProjectOptions.Title
            } ).SingleOrDefaultAsync();

            if ( exists != null )
                return new ApiResult<Project>(StatusCode.Conflict, " Project already exists " );

            var tempProject = new Project()
            {
                Title = CreateProjectOptions.Title,
                Description = CreateProjectOptions.Description,
                Cost = CreateProjectOptions.Cost,
                Photo = CreateProjectOptions.Photo,
                Category = CreateProjectOptions.Category,
                CreatorId = creatorId

            };

            var success = false;

            await context_.AddAsync( tempProject );
            try {
                success = await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error save Project : {tempProject.Title} " );
                return new ApiResult<Project>
                    ( StatusCode.InternalServerError, " Error save Project " );
            }

            return ApiResult<Project>.CreateSuccess( tempProject );
        }

        public IQueryable<Project> SearchProject( 
            SearchProjectOptions searchProjectOptions ) {

            if ( searchProjectOptions == null )
                return null;

            var query = context_
                .Set<Project>()
                .AsQueryable();

            if ( searchProjectOptions.Category != 0 )
                query = query
                    .Where( p => p.Category == searchProjectOptions.Category );

            if ( !string.IsNullOrWhiteSpace( searchProjectOptions.Title ) )
                query = query
                    .Where( p => p.Title == searchProjectOptions.Title );
           
            return query.Take( 500 );
        }  

        public async Task<ApiResult<Project>> SearchProjectByIdAsync( int projectId ) {

            if ( projectId <= 0 )
                return new ApiResult<Project>(StatusCode.BadRequest, " id is invalid " );

            var tempProject = await context_
                .Set<Project>()
                .SingleOrDefaultAsync( p => p.Id == projectId );

            if ( tempProject == null )
                return null;

            return ApiResult<Project>.CreateSuccess( tempProject );
        }
        
        public async Task<ApiResult<Project>>  UpdateProjectInfoAsync(int projectId, UpdateProjectOptions options) {

            if ( options == null )
                return new ApiResult<Project>(StatusCode.BadRequest, " Options are null " );

            if ( projectId <= 0 )
                return new ApiResult<Project>( StatusCode.BadRequest, " Id is invalid " );

            var tempProject = await SearchProjectByIdAsync( projectId );

            if ( tempProject == null )
                return new ApiResult<Project>( StatusCode.NotFound, " Project not found  " );

            if ( !string.IsNullOrEmpty( options.Title ) )
                tempProject.Data.Title = options.Title;

            if ( !string.IsNullOrEmpty( options.Description ) )
                tempProject.Data.Description = options.Description;

            if ( options.Cost != 0 )
                tempProject.Data.Cost = options.Cost;

            if ( !string.IsNullOrEmpty( options.Photo ) )
                tempProject.Data.Photo = options.Photo;

           var  success = false;
            try {
                success = await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error update Project : {tempProject.Data.Title} " );
                return new ApiResult<Project>
                    ( StatusCode.InternalServerError, " Error update Project " );
            }


            return ApiResult<Project>.CreateSuccess( tempProject.Data );
        }

        public async Task<ApiResult<Project>> BuyProjectAsync(int projectId, int backerId, int rewardId ) {

            if ( projectId <= 0 ||
                backerId <= 0 ||
                rewardId <= 0 )
                return new ApiResult<Project>( StatusCode.BadRequest, " Ids are null " );

            var tempProject = await SearchProjectByIdAsync( projectId );

            if ( tempProject.Data == null )
                return new ApiResult<Project>( StatusCode.NotFound, " Project not found " );

            var tempBacker = await bsvc_.SearchBackerByIdAsync( backerId );

            if ( tempBacker.Data == null )
                return new ApiResult<Project>( StatusCode.NotFound, " Backer not found " );

            var tempReward = await rsvc_.SearchRewardByIdAsync( rewardId );

            if ( tempReward.Data == null )
                return new ApiResult<Project>( StatusCode.NotFound, " Reward not found " );

            var tempBp = new BackerProject()
            {
                BackerId = backerId,
                ProjectId = projectId
            };

            tempBacker.Data.MyFundedProjects.Add( tempBp );

            var tempBr = new BackerReward()
            {
                BackerId = backerId,
                RewardId = rewardId
            };

            tempBacker.Data.BackerRewards.Add( tempBr );

            tempProject.Data.FinancialProgress = tempProject.Data.FinancialProgress + tempReward.Data.Price;

            var success = false;
            try {
                success =await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error save  Project : {tempProject.Data.Title} " );
                return new ApiResult<Project>
                    ( StatusCode.InternalServerError, " Error save  Project " );
            }


            return ApiResult<Project>.CreateSuccess(new ApiResult<Project>(success).Data);

            




        }


    }
}
