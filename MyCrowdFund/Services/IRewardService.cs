using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public interface IRewardService {
        Task<ApiResult<Reward>> CreateRewardAsync( int creatorId, int projectId, CreateRewardOptions options );
        IQueryable<Reward> SearchReward( SearchRewardOptions options );
        Task<ApiResult<Reward>> SearchRewardByIdAsync( int rewardId );
        Task<ApiResult<Reward>> UpdateRewardinfoAsync( int rewardId, UpdateRewardOptions options );
    }
}