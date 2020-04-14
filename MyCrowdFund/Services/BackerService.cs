using Microsoft.EntityFrameworkCore;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
   public  class BackerService : IBackerService
    {

        private readonly MyCrowdFundDbContext context_;
        private readonly ILoggerService log_;

        public BackerService( MyCrowdFundDbContext context, ILoggerService log ) {

            context_ = context;
            log_ = log;
        }

        public async Task<ApiResult<Backer>> CreateBackerAsync(CreateBackerOptions createOptions) {

            if ( createOptions == null )
                return new ApiResult<Backer>(StatusCode.BadRequest, " null fields ");

            if ( string.IsNullOrWhiteSpace( createOptions.Firstname ) )
                return new ApiResult<Backer>( StatusCode.BadRequest, " Firstname is null " );

            if ( string.IsNullOrWhiteSpace( createOptions.Lastname ) )
                return new ApiResult<Backer>( StatusCode.BadRequest, " Lastname is null " );

            if ( createOptions.Age <= 18 )
                return new ApiResult<Backer>( StatusCode.BadRequest, " Age is invalid " );

            if ( string.IsNullOrWhiteSpace( createOptions.Email ) )
                return new ApiResult<Backer>( StatusCode.BadRequest, " email is invalid " );

            if ( string.IsNullOrWhiteSpace( createOptions.Photo ) )
                return new ApiResult<Backer>( StatusCode.BadRequest, " photo link is null " );

            var exists = await SearchBacker( new SearchBackerOptions()
            {
                Email = createOptions.Email
            } ).SingleOrDefaultAsync( b => b.Email == createOptions.Email );

            if( exists != null ) {
                return null;

            }

            var newBacker = new Backer()
            {
                Firstname = createOptions.Firstname,
                Lastname = createOptions.Lastname,
                Age = createOptions.Age,
                Email = createOptions.Email,
                Photo = createOptions.Photo,
                DateCreated = DateTime.Now
            };

           await context_.AddAsync( newBacker );

            try {
               await context_.SaveChangesAsync();
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error save Backer : {newBacker.Lastname} " );
                return new ApiResult<Backer>
                    ( StatusCode.InternalServerError, " Error save Backer " );
            }
            

            return ApiResult<Backer>.CreateSuccess( newBacker );
        }

        public IQueryable<Backer> SearchBacker(SearchBackerOptions searchOptions) {

            if ( searchOptions == null )
                return null;

            var query = context_
                .Set<Backer>()
                .AsQueryable();

            if ( !string.IsNullOrWhiteSpace( searchOptions.Email ) )
                query = query
                    .Where( b => b.Email == searchOptions.Email );

            if ( !string.IsNullOrWhiteSpace( searchOptions.Firstname ) )
                query = query
                    .Where( b => b.Firstname == searchOptions.Firstname );

            if ( !string.IsNullOrWhiteSpace( searchOptions.Lastname ) )
                query = query
                    .Where( b => b.Lastname == searchOptions.Lastname );

            return query.Take( 500 );

        }

        public async Task<ApiResult<Backer>> SearchBackerByIdAsync( int backerId ) {

            if ( backerId <= 0 )
                return new ApiResult<Backer>(StatusCode.BadRequest, "Backer's Id is null ");

            var tempBacker = await context_
                .Set<Backer>()
                .SingleOrDefaultAsync( b => b.Id == backerId );

            if ( tempBacker == null )
                return null;

            return ApiResult<Backer>.CreateSuccess( tempBacker );

        }

        public async Task<ApiResult<Backer>> UpdateBackerInfoAsync(int backerId,
            UpdateBackerOptions updateOptions ) {

            if ( updateOptions == null )
                return new ApiResult<Backer>(StatusCode.BadRequest, " Null options " );

            if ( backerId <= 0 )
                return new ApiResult<Backer>( StatusCode.BadRequest, " Backer's Id is invalid " );

            var tempBacker = await SearchBackerByIdAsync( backerId );

            if ( !string.IsNullOrWhiteSpace( updateOptions.Lastname ) )
                tempBacker.Data.Lastname = updateOptions.Lastname;

            if ( updateOptions.Age >= 18 )
                tempBacker.Data.Age = updateOptions.Age;

            if ( !string.IsNullOrWhiteSpace( updateOptions.Email ) )
                tempBacker.Data.Email = updateOptions.Email;

            if ( !string.IsNullOrWhiteSpace( updateOptions.Photo ) )
                tempBacker.Data.Photo = updateOptions.Photo;

            var success = false;
            try {
               success = await context_.SaveChangesAsync() >0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error update Backer : {tempBacker.Data.Lastname} " );
                return new ApiResult<Backer>
                    ( StatusCode.InternalServerError, " Error update Backer info " );
            }

            return ApiResult<Backer>.CreateSuccess( tempBacker.Data );
        }
    }
}
