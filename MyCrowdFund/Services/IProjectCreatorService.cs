using MyCrowdFund.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public interface IProjectCreatorService {

        Task<ApiResult<ProjectCreator>> NewProjectCretorAsync( ProjectCreatorOptions creatorOptions );

        IQueryable<ProjectCreator> SearchProjectCreator(
            SearchProjectCreatorOptions searchOptions );

        Task<ApiResult<ProjectCreator>> SearchProjectCreatorByIdAsync( int creatorId );

        Task<ApiResult<ProjectCreator>> UpdateProjectCreatorInfoAsync( int creatorId, 
            UpdateProjectCreatorOptions updateOptions );
    }
}
