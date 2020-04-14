using Microsoft.EntityFrameworkCore;
using MyCrowdFund.Data;
using MyCrowdFund.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrowdFund.Services {
    class ProjectCreatorService : IProjectCreatorService 
    {

        private readonly MyCrowdFundDbContext context_;
        private readonly ILoggerService log_;

        public ProjectCreatorService(MyCrowdFundDbContext context, ILoggerService log ) {

            context_ = context;
            log_ = log;
        }

      

        public async Task<ApiResult<ProjectCreator>> NewProjectCretorAsync( ProjectCreatorOptions creatorOptions ) {

            if ( creatorOptions == null )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " null fields " );


            if ( string.IsNullOrWhiteSpace( creatorOptions.Firstname ) )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, "Firstname is null " );

            if ( string.IsNullOrWhiteSpace( creatorOptions.Lastname ) )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Lastname is null " );

            if ( creatorOptions.Age < 18 )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Age is invalid " );

            if ( string.IsNullOrWhiteSpace( creatorOptions.Email ) )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Email is invalid " );

            if ( string.IsNullOrWhiteSpace( creatorOptions.Photo ) )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Photo's link is null " );

            var exists = await  SearchProjectCreator(
                new SearchProjectCreatorOptions()
                {
                    Email = creatorOptions.Email,
                } ).SingleOrDefaultAsync( c => c.Email == creatorOptions.Email );

            if ( exists != null )
                return null;

            var newProjectCreator = new ProjectCreator()
            {
                Firstname = creatorOptions.Firstname,
                Lastname = creatorOptions.Lastname,
                Age = creatorOptions.Age,
                Email = creatorOptions.Email,
                Photo = creatorOptions.Photo,
                DateCreated = DateTime.Now
            };

           await context_.AddAsync( newProjectCreator );
            try {
                await context_.SaveChangesAsync();
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error save ProjectCreator : {newProjectCreator.Lastname} " );
                return new ApiResult<ProjectCreator>
                    ( StatusCode.InternalServerError, " Error save ProjectCreator " );
            }

            return  ApiResult<ProjectCreator>.CreateSuccess(newProjectCreator);
        }

        public IQueryable<ProjectCreator> SearchProjectCreator(SearchProjectCreatorOptions searchOptions) {

            if (searchOptions == null)
                return null;

            var query = context_
                .Set<ProjectCreator>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchOptions.Firstname))
                query = query.Where(c => c.Firstname == searchOptions.Firstname);

            if (!string.IsNullOrWhiteSpace(searchOptions.Lastname))
                query = query.Where(c => c.Lastname == searchOptions.Lastname);

            if (!string.IsNullOrWhiteSpace(searchOptions.Email))
                query = query.Where(c => c.Email == searchOptions.Email);

            return query.Take(500);
        }

        public async Task<ApiResult<ProjectCreator>> SearchProjectCreatorByIdAsync( int creatorId ) {

            if ( creatorId <= 0 )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " null creator's id" );

            var tempCreator = await context_
                .Set<ProjectCreator>()
                .SingleOrDefaultAsync( c => c.Id == creatorId );

            if ( tempCreator == null )
                return null;

            return ApiResult<ProjectCreator>.CreateSuccess( tempCreator );
        }

        public async Task<ApiResult<ProjectCreator>> UpdateProjectCreatorInfoAsync (int creatorId, 
            UpdateProjectCreatorOptions updateOptions ) {

            if ( updateOptions == null )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " null options " );

            if ( creatorId <= 0 )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Creator Id is invalid " );

            var tempCreator = await SearchProjectCreatorByIdAsync( creatorId );

            if ( tempCreator == null )
                return new ApiResult<ProjectCreator>( StatusCode.BadRequest, " Creator not found " );        

            if ( !string.IsNullOrWhiteSpace(updateOptions.Lastname))
                tempCreator.Data.Lastname = updateOptions.Lastname;

            if (updateOptions.Age >= 18)
                tempCreator.Data.Age = updateOptions.Age;

            if (!string.IsNullOrWhiteSpace(updateOptions.Email))
                tempCreator.Data.Email = updateOptions.Email;

            if (!string.IsNullOrWhiteSpace(updateOptions.Photo))
                tempCreator.Data.Photo = updateOptions.Photo;

            var success = false;
            try {
               success = await context_.SaveChangesAsync() > 0;
            }
            catch {

                log_.LogError
                    ( StatusCode.InternalServerError, $"Error update ProjectCreator : {tempCreator.Data.Lastname} " );
                return new ApiResult<ProjectCreator>
                    ( StatusCode.InternalServerError, " Error update ProjectCreator " );
            }

            return ApiResult<ProjectCreator>.CreateSuccess(tempCreator.Data);
        }       
    }
}
