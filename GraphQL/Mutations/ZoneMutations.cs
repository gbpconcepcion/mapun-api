using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddZoneInputs;
using mapun_api.GQL.InputTypes.EditInput.EditZoneInputs;
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
        public async Task<Response> AddZoneAsync(
            AddZoneInput input,
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
                var zone = new mapun_api.Models.Entities.Zone
                {
                    ZONE_NAME = input.ZONE_NAME,
                    ZONE_DESCRIPTION = input.ZONE_DESCRIPTION,
                    ZONE_AREA = input.ZONE_AREA,
                    ZRATE_ID = input.ZRATE_ID,
                    ZONE_AREACODE = input.ZONE_AREACODE,
                    ZONE_LATITUDE = input.ZONE_LATITUDE,
                    ZONE_LONGITUDE = input.ZONE_LONGITUDE,
                    IS_ACTIVE = true,


                };

                context.ZONES.Add(zone);

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
        public async Task<Response> EditZoneAsync(
            EditZoneInput edit,
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
                var zone = await context.FindAsync<Zone>(edit.ZONE_ID);

                if (edit.ZONE_NAME != null)
                    zone.ZONE_NAME = edit.ZONE_NAME;

                if (edit.ZONE_DESCRIPTION != null)
                    zone.ZONE_DESCRIPTION = edit.ZONE_DESCRIPTION;

                if (edit.ZONE_AREA != null)
                    zone.ZONE_AREA = edit.ZONE_AREA;

                if (edit.ZONE_AREACODE != null)
                    zone.ZONE_AREACODE = edit.ZONE_AREACODE;

                if (edit.ZONE_LATITUDE != null)
                    zone.ZONE_LATITUDE = edit.ZONE_LATITUDE;

                if (edit.ZONE_LONGITUDE != null)
                    zone.ZONE_LONGITUDE = edit.ZONE_LONGITUDE;

                if (edit.ZRATE_ID != null)
                    zone.ZRATE_ID = edit.ZRATE_ID;



                context.ZONES.Update(zone);

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