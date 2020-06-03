using Microsoft.EntityFrameworkCore;
using MyCrowdFund.Data;
using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public class RewardService : IRewardService {

        private readonly MyCrowdFundDbContext context_;
      
        private readonly ILoggerService log_;


        public RewardService( MyCrowdFundDbContext context,
           ILoggerService log  ) {

            context_ = context;
          
            log_ = log;
        }

        public async Task<ApiResult<Reward>> CreateRewardAsync( int creatorId, int projectId,
            CreateRewardOptions options ) {

            if ( creatorId == 0 )
                return new ApiResult<Reward>(StatusCode.BadRequest, " Creator's Id is invalid " );

            if ( projectId == 0 )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Project's Id is invalid " );

            if ( options == null )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Options are null " );

            if ( string.IsNullOrWhiteSpace( options.Title ) )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Title is null" );

            if ( string.IsNullOrWhiteSpace( options.Description ) )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Description is null" );

            if ( options.Price <= 0 )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Price is invalid " );

            var search = await SearchReward( new SearchRewardOptions()
            {
                Title = options.Title
            } ).SingleOrDefaultAsync();

            if ( search != null )
                return new ApiResult<Reward>( StatusCode.NotFound, " Reward exists " );

            var newReward = new Reward()
            {
                Title = options.Title,
                Description = options.Description,
                Price = options.Price,
                RewardCreatorId = creatorId,
                ProjectId = projectId
            };

        

            var success = false;

           await context_.AddAsync( newReward );
            try {
                success = await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error save Reward : {newReward.Title} " );
                return new ApiResult<Reward>
                    ( StatusCode.InternalServerError, " Error save Reward " );
            }

            return ApiResult<Reward>.CreateSuccess( newReward );

        }

        public IQueryable<Reward> SearchReward( SearchRewardOptions options ) {

            if ( options == null )
                return null;

            if ( string.IsNullOrWhiteSpace( options.Title ) )
                return null;

            var query = context_
                .Set<Reward>()
                .AsQueryable();

            if ( query != null )
                query = query.Where( r => r.Title == options.Title );

            return query.Take( 500 );

        }

        public async Task<ApiResult<Reward>> SearchRewardByIdAsync( int rewardId ) {

            if ( rewardId <= 0 )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Reward's Id is invalid " );

            var tempReward = await context_
                .Set<Reward>()
                .SingleOrDefaultAsync( r => r.Id == rewardId );

            if ( tempReward == null )
                return new ApiResult<Reward>( StatusCode.NotFound, " Reward not found " );

            return ApiResult<Reward>.CreateSuccess( tempReward );
        }

        public async Task<ApiResult<Reward>> UpdateRewardinfoAsync( int rewardId, UpdateRewardOptions options ) {

            if ( options == null )
                return new ApiResult<Reward>( StatusCode.BadRequest, " Options are null " );

            var search = await SearchRewardByIdAsync( rewardId );

            if ( !string.IsNullOrWhiteSpace( options.Title ) )
                search.Data.Title = options.Title;

            if ( !string.IsNullOrWhiteSpace( options.Description ) )
                search.Data.Description = options.Description;

            if ( options.Price > 0 )
                search.Data.Price = options.Price;

            var success = false;
            try {
                success = await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error update Reward : {search.Data.Title} " );
                return new ApiResult<Reward>
                    ( StatusCode.InternalServerError, " Error update Reward " );
            }

            return ApiResult<Reward>.CreateSuccess( new ApiResult<Reward>( success ).Data );

        }

    }
}
