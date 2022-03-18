using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddUserInputs;
using mapun_api.GQL.InputTypes.EditInput.EditUserInputs;
using System.Threading;
using System.Net;
using Serilog;
using HotChocolate;
using mapun_api.Data;
using HotChocolate.Data;
using System.Threading.Tasks;
using System;
using System.IO;
using Azure.Storage.Blobs;
using Dapper.Extensions;
using HotChocolate.Types;
using Microsoft.Extensions.Configuration;
using Path = System.IO.Path;

namespace mapun_api.GQL.Mutation
{
    public partial class Mutation
    {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Response> AddUserAsync(
            AddUserInput input,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
        )
        {
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            //for testing
            // decode the token using the keycloak token reader
            // var token = keycloakTokenReader.decodeToken();
            // Contains the session data of user - get the GUID of current user
            // var appUser = new Guid(token.Payload["sub"].ToString() ?? string.Empty);
            var appUser = new Guid();

            try
            {
                var user = new mapun_api.Models.Entities.User
                {
                    FIRSTNAME = input.FIRSTNAME,
                    MIDDLENAME = input.MIDDLENAME,
                    LASTNAME = input.LASTNAME,
                    USERNAME = input.USERNAME,
                    ROLE_ID = input.ROLE_ID,
                    EMAIL = input.EMAIL,
                    IS_ACTIVE = true


                };

                context.USERS.Add(user);

                await context.SaveSessionChangesAsync(cancellationToken, appUser);

                await transaction.CommitAsync(cancellationToken);

                return new Response
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ResponseMessage = "Status Successfully Created",
                    ResponseLabel = "Status Successfully Created"
                };

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                Log.Fatal(e, "Error in AddAStatusAsync Mutation by {User}", appUser);
                throw new GraphQLException(ErrorBuilder.New()
                    .SetMessage("There was an error while adding task state")
                    .SetCode("Mutation-AddAStatusAsync-Exception")
                    .SetException(e)
                    .SetExtension("statusCode", (int)HttpStatusCode.InternalServerError)
                    .Build());
            }
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Response> EditUserAsync(
            EditUserInput edit,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
        )
        {
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            // decode the token using the keycloak token reader
            //var token = keycloakTokenReader.decodeToken();
            // Contains the session data of user - get the GUID of current user
            //var appUser = new Guid(token.Payload["sub"].ToString() ?? string.Empty);


            var appUser = new Guid();
            try
            {
                var user = await context.FindAsync<User>(edit.USER_ID);

                if (edit.FIRSTNAME != null)
                    user.FIRSTNAME = edit.FIRSTNAME;

                if (edit.MIDDLENAME != null)
                    user.MIDDLENAME = edit.MIDDLENAME;

                if (edit.LASTNAME != null)
                    user.LASTNAME = edit.LASTNAME;

                if (edit.USERNAME != null)
                    user.USERNAME = edit.USERNAME;

                if (edit.EMAIL != null)
                    user.EMAIL = edit.EMAIL;

                if (edit.ROLE_ID != null)
                    user.ROLE_ID = edit.ROLE_ID;




                context.USERS.Update(user);

                await context.SaveSessionChangesAsync(cancellationToken, appUser);

                await transaction.CommitAsync(cancellationToken);

                return new Response
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ResponseMessage = "Status Successfully Created",
                    ResponseLabel = "Status Successfully Created"
                };
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw e;

                // var timestamp = clockService.InTicks;
                // Log.Fatal(e, "Error in EditAStatusAsync Mutation by {User} {TimeStamp}", appUser, timestamp);
                // throw new GraphQLException(ErrorBuilder.New()
                //     .SetMessage($"There was an error while processing your request {timestamp}")
                //     .SetCode("Mutation-EditAStatusAsync-Exception")
                //     .SetException(e)
                //     .SetExtension("statusCode", (int)HttpStatusCode.InternalServerError)
                //     .Build());
            }
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Response> AddRoleAsync(
            AddRoleInput input,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
        )
        {
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            //for testing
            // decode the token using the keycloak token reader
            // var token = keycloakTokenReader.decodeToken();
            // Contains the session data of user - get the GUID of current user
            // var appUser = new Guid(token.Payload["sub"].ToString() ?? string.Empty);
            var appUser = new Guid();

            try
            {
                var role = new mapun_api.Models.Entities.mapunRole
                {
                    TITLE = input.TITLE,
                    IS_ACTIVE = true,


                };

                context.ROLES.Add(role);

                await context.SaveSessionChangesAsync(cancellationToken, appUser);

                await transaction.CommitAsync(cancellationToken);

                return new Response
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ResponseMessage = "Status Successfully Created",
                    ResponseLabel = "Status Successfully Created"
                };

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                Log.Fatal(e, "Error in AddAStatusAsync Mutation by {User}", appUser);
                throw new GraphQLException(ErrorBuilder.New()
                    .SetMessage("There was an error while adding task state")
                    .SetCode("Mutation-AddAStatusAsync-Exception")
                    .SetException(e)
                    .SetExtension("statusCode", (int)HttpStatusCode.InternalServerError)
                    .Build());
            }
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Response> EditRoleAsync(
            EditRoleInput edit,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
        )
        {
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            // decode the token using the keycloak token reader
            //var token = keycloakTokenReader.decodeToken();
            // Contains the session data of user - get the GUID of current user
            //var appUser = new Guid(token.Payload["sub"].ToString() ?? string.Empty);


            var appUser = new Guid();
            try
            {
                var role = await context.FindAsync<mapunRole>(edit.ROLE_ID);



                if (edit.TITLE != null)
                    role.TITLE = edit.TITLE;





                context.ROLES.Update(role);

                await context.SaveSessionChangesAsync(cancellationToken, appUser);

                await transaction.CommitAsync(cancellationToken);

                return new Response
                {
                    ResponseCode = (int)HttpStatusCode.OK,
                    ResponseMessage = "Status Successfully Created",
                    ResponseLabel = "Status Successfully Created"
                };
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw e;

                // var timestamp = clockService.InTicks;
                // Log.Fatal(e, "Error in EditAStatusAsync Mutation by {User} {TimeStamp}", appUser, timestamp);
                // throw new GraphQLException(ErrorBuilder.New()
                //     .SetMessage($"There was an error while processing your request {timestamp}")
                //     .SetCode("Mutation-EditAStatusAsync-Exception")
                //     .SetException(e)
                //     .SetExtension("statusCode", (int)HttpStatusCode.InternalServerError)
                //     .Build());
            }
        }


    }
}