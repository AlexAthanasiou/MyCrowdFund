using MyCrowdFund.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    public interface IBackerService {

         Task<ApiResult<Backer>> CreateBackerAsync( CreateBackerOptions createOptions );

        IQueryable<Backer> SearchBacker( SearchBackerOptions searchOptions );

         Task<ApiResult<Backer>> SearchBackerByIdAsync( int backerId );


         Task<ApiResult<Backer>> UpdateBackerInfoAsync( int backerId,
            UpdateBackerOptions updateOptions );
    }  
}
