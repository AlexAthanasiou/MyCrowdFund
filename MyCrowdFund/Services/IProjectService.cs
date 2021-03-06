﻿using MyCrowdFund.Model;
using MyCrowdFund.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public interface IProjectService {

        Task<ApiResult<Project>> CreateProjectAsync( int creatorId, 
            CreateProjectOptions CreateProjectOptions );

        IQueryable<Project> SearchProject(
            SearchProjectOptions searchProjectOptions );

        Task<ApiResult<Project>> SearchProjectByIdAsync( int projectId );

        Task<ApiResult<BackerProject>> BuyProjectAsync (int projectId, int backerId, int rewardId );
    }
}
