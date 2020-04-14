using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public interface IProjectService {

        Task<ApiResult<Project>> CreateProjectAsync( int creatorId, 
            CreateProjectOptions CreateProjectOptions );

        IQueryable<Project> SearchProject(
            SearchProjectOptions searchProjectOptions );

        Task<ApiResult<Project>> SearchProjectByIdAsync( int projectId );

        Task<ApiResult<Project>> BuyProjectAsync (int projectId, int backerId, int rewardId );
    }
}
