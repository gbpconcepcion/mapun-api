using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddRatesInputs;
using mapun_api.GQL.InputTypes.EditInput.EditRatesInputs;
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
        public async Task<Response> AddBRateAsync(
            AddBRateInput input,
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
                var brate = new mapun_api.Models.Entities.BaseRate
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    RATE = input.RATE,
                    IS_ACTIVE = true,


                };

                context.BRATES.Add(brate);

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
        public async Task<Response> EditPropertyAsync(
            EditBRateInput edit,
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
                var brate = await context.FindAsync<BaseRate>(edit.BRATE_ID);

                if (edit.DESCRIPTION != null)
                    brate.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    brate.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    brate.REMARKS = edit.REMARKS;

                if (edit.RATE != null)
                    brate.RATE = edit.RATE;

                context.BRATES.Update(brate);

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
        public async Task<Response> AddMRateAsync(
            AddMRateInput input,
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
                var mrate = new mapun_api.Models.Entities.MiscRate
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    RATE = input.RATE,
                    IS_ACTIVE = true,


                };

                context.MRATES.Add(mrate);

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
        public async Task<Response> EditMRateAsync(
            EditMRateInput edit,
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
                var mrate = await context.FindAsync<MiscRate>(edit.MRATE_ID);

                if (edit.DESCRIPTION != null)
                    mrate.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    mrate.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    mrate.REMARKS = edit.REMARKS;

                if (edit.RATE != null)
                    mrate.RATE = edit.RATE;


                context.MRATES.Update(mrate);

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
        public async Task<Response> AddERateAsync(
            AddERateInput input,
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
                var erate = new mapun_api.Models.Entities.EnhancementRate
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    RATE = input.RATE,
                    IS_ACTIVE = true,


                };

                context.ERATES.Add(erate);

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
        public async Task<Response> EditERateAsync(
            EditERateInput edit,
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
                var erate = await context.FindAsync<EnhancementRate>(edit.ERATE_ID);

                if (edit.DESCRIPTION != null)
                    erate.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    erate.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    erate.REMARKS = edit.REMARKS;

                if (edit.RATE != null)
                    erate.RATE = edit.RATE;





                context.ERATES.Update(erate);

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
        public async Task<Response> AddZRateAsync(
            AddZRateInput input,
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
                var zrate = new mapun_api.Models.Entities.ZoneRate
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    RATE = input.RATE,
                    IS_ACTIVE = true,


                };

                context.ZRATES.Add(zrate);

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
        public async Task<Response> EditZRateInput(
            EditZRateInput edit,
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
                var zrate = await context.FindAsync<ZoneRate>(edit.ZRATE_ID);

                if (edit.DESCRIPTION != null)
                    zrate.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    zrate.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    zrate.REMARKS = edit.REMARKS;

                if (edit.RATE != null)
                    zrate.RATE = edit.RATE;





                context.ZRATES.Update(zrate);

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