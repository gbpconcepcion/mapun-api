using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddPropertyInputs;
using mapun_api.GQL.InputTypes.EditInput.EditPropertyInputs;
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
        public async Task<Response> AddPropertyAsync(
            AddPropertyInput input,
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
                var property = new mapun_api.Models.Entities.Property
                {
                    PROPERTY_IDENTIFICATION_NUMBER = input.PROPERTY_IDENTIFICATION_NUMBER,
                    ARP_NO = input.ARP_NO,
                    TCT_CLOA_NO = input.TCT_CLOA_NO,
                    OCT_NO = input.OCT_NO,
                    TD_NO = input.TD_NO,
                    LOT_NO = input.LOT_NO,
                    BLOCK_NO = input.BLOCK_NO,
                    BOUNDARY_NORTH = input.BOUNDARY_NORTH,
                    BOUNDARY_SOUTH = input.BOUNDARY_SOUTH,
                    BOUNDARY_WEST = input.BOUNDARY_WEST,
                    BOUNDARY_EAST = input.BOUNDARY_EAST,
                    PROPERTY_NAME = input.PROPERTY_NAME,
                    DATE_FILLED = input.DATE_FILLED,
                    PROPERTY_LONGITUDE = input.PROPERTY_LONGITUDE,
                    PROPERTY_LATITUDE = input.PROPERTY_LATITUDE,
                    OWNER_NAME = input.OWNER_NAME,
                    OWNER_ADDRESS = input.OWNER_ADDRESS,
                    OWNER_TIN = input.OWNER_TIN,
                    OWNER_TEL = input.OWNER_TEL,
                    ADMINISTRATOR_NAME = input.ADMINISTRATOR_NAME,
                    ADMINISTRATOR_ADDRESS = input.ADMINISTRATOR_ADDRESS,
                    ADMINISTRATOR_TIN = input.ADMINISTRATOR_TIN,
                    ADMINISTRATOR_TEL = input.ADMINISTRATOR_TEL,
                    PROPERTY_STREET = input.PROPERTY_STREET,
                    PROPERTY_BARANGAY = input.PROPERTY_BARANGAY,
                    PROPERTY_MUNICIPALITY = input.PROPERTY_MUNICIPALITY,
                    MEMORANDA = input.MEMORANDA,
                    PROVINCE = input.PROVINCE,
                    EMAIL = input.EMAIL,
                    PSTATUS_ID = input.PSTATUS_ID,
                    PEHANCEMENT_ID = input.PEHANCEMENT_ID,
                    MRATE_ID = input.MRATE_ID,
                    BRATE_ID = input.BRATE_ID,
                    ZONE_ID = input.ZONE_ID,
                    IS_ACTIVE = true,


                };

                context.PROPERTIES.Add(property);

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
            EditPropertyInput edit,
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
                var property = await context.FindAsync<Property>(edit.PROPERTY_ID);

                if (edit.ARP_NO != null)
                    property.ARP_NO = edit.ARP_NO;

                if (edit.TCT_CLOA_NO != null)
                    property.TCT_CLOA_NO = edit.TCT_CLOA_NO;

                if (edit.ARP_NO != null)
                    property.ARP_NO = edit.ARP_NO;

                if (edit.OCT_NO != null)
                    property.OCT_NO = edit.OCT_NO;

                if (edit.TD_NO != null)
                    property.TD_NO = edit.TD_NO;

                if (edit.DATE_FILLED != null)
                    property.DATE_FILLED = edit.DATE_FILLED;

                if (edit.BLOCK_NO != null)
                    property.BLOCK_NO = edit.BLOCK_NO;

                if (edit.BOUNDARY_NORTH != null)
                    property.BOUNDARY_NORTH = edit.BOUNDARY_NORTH;

                if (edit.BOUNDARY_SOUTH != null)
                    property.BOUNDARY_SOUTH = edit.BOUNDARY_SOUTH;

                if (edit.BOUNDARY_WEST != null)
                    property.BOUNDARY_WEST = edit.BOUNDARY_WEST;

                if (edit.BOUNDARY_EAST != null)
                    property.BOUNDARY_EAST = edit.BOUNDARY_EAST;

                if (edit.MEMORANDA != null)
                    property.MEMORANDA = edit.MEMORANDA;

                if (edit.PROPERTY_NAME != null)
                    property.PROPERTY_NAME = edit.PROPERTY_NAME;

                if (edit.PROPERTY_LONGITUDE != null)
                    property.PROPERTY_LONGITUDE = edit.PROPERTY_LONGITUDE;

                if (edit.PROPERTY_LATITUDE != null)
                    property.PROPERTY_LATITUDE = edit.PROPERTY_LATITUDE;

                if (edit.OWNER_NAME != null)
                    property.OWNER_NAME = edit.OWNER_NAME;

                if (edit.OWNER_ADDRESS != null)
                    property.OWNER_ADDRESS = edit.OWNER_ADDRESS;

                if (edit.OWNER_TIN != null)
                    property.OWNER_TIN = edit.OWNER_TIN;

                if (edit.OWNER_TEL != null)
                    property.OWNER_TEL = edit.OWNER_TEL;

                if (edit.ADMINISTRATOR_NAME != null)
                    property.ADMINISTRATOR_NAME = edit.ADMINISTRATOR_NAME;

                if (edit.ADMINISTRATOR_ADDRESS != null)
                    property.ADMINISTRATOR_ADDRESS = edit.ADMINISTRATOR_ADDRESS;

                if (edit.ADMINISTRATOR_TIN != null)
                    property.ADMINISTRATOR_TIN = edit.ADMINISTRATOR_TIN;

                if (edit.ADMINISTRATOR_TEL != null)
                    property.ADMINISTRATOR_TEL = edit.ADMINISTRATOR_TEL;

                if (edit.PROPERTY_STREET != null)
                    property.PROPERTY_STREET = edit.PROPERTY_STREET;

                if (edit.PROPERTY_BARANGAY != null)
                    property.PROPERTY_BARANGAY = edit.PROPERTY_BARANGAY;

                if (edit.PROPERTY_MUNICIPALITY != null)
                    property.PROPERTY_MUNICIPALITY = edit.PROPERTY_MUNICIPALITY;

                if (edit.PROVINCE != null)
                    property.PROVINCE = edit.PROVINCE;

                if (edit.EMAIL != null)
                    property.EMAIL = edit.EMAIL;

                if (edit.PSTATUS_ID != null)
                    property.PSTATUS_ID = edit.PSTATUS_ID;

                if (edit.PEHANCEMENT_ID != null)
                    property.PEHANCEMENT_ID = edit.PEHANCEMENT_ID;

                if (edit.MRATE_ID != null)
                    property.MRATE_ID = edit.MRATE_ID;

                if (edit.BRATE_ID != null)
                    property.BRATE_ID = edit.BRATE_ID;

                if (edit.ZONE_ID != null)
                    property.ZONE_ID = edit.ZONE_ID;

                context.PROPERTIES.Update(property);

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
        public async Task<Response> AddPEnhancementAsync(
            AddPEnhancementInput input,
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
                var enhancement = new mapun_api.Models.Entities.PropertyEnhancement
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    ENHANCEMENT_TYPE = input.ENHANCEMENT_TYPE,
                    ERATE_ID = input.ERATE_ID,
                    IS_ACTIVE = true,


                };

                context.PENHANCEMENTS.Add(enhancement);

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
        public async Task<Response> EditPEnhancementAsync(
            EditPEnhancementInput edit,
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
                var enhancement = await context.FindAsync<PropertyEnhancement>(edit.PEHANCMENT_ID);

                if (edit.DESCRIPTION != null)
                    enhancement.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    enhancement.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    enhancement.REMARKS = edit.REMARKS;

                if (edit.ENHANCEMENT_TYPE != null)
                    enhancement.ENHANCEMENT_TYPE = edit.ENHANCEMENT_TYPE;

                if (edit.ERATE_ID != null)
                    enhancement.ERATE_ID = edit.ERATE_ID;



                context.PENHANCEMENTS.Update(enhancement);

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
        public async Task<Response> AddPLogAsync(
            AddPLogsInput input,
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
                var log = new mapun_api.Models.Entities.PropertyLog
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    USER_ID = input.USER_ID,
                    PROPERTY_ID = input.PROPERTY_ID,
                    IS_ACTIVE = true,


                };

                context.PLOGS.Add(log);

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
        public async Task<Response> EditPLogAsync(
            EditPLogsInput edit,
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
                var log = await context.FindAsync<PropertyLog>(edit.PLOG_ID);

                if (edit.DESCRIPTION != null)
                    log.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    log.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    log.REMARKS = edit.REMARKS;

                if (edit.USER_ID != null)
                    log.USER_ID = edit.USER_ID;

                if (edit.PROPERTY_ID != null)
                    log.PROPERTY_ID = edit.PROPERTY_ID;





                context.PLOGS.Update(log);

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
        public async Task<Response> AddPStatusAsync(
            AddPStatusInput input,
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
                var status = new mapun_api.Models.Entities.PropertyStatus
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    ORDER = input.ORDER,
                    IS_ACTIVE = true,


                };

                context.PSTATUSES.Add(status);

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
        public async Task<Response> EditPStatusAsync(
            EditPStatusInput edit,
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
                var status = await context.FindAsync<PropertyStatus>(edit.PSTATUS_ID);

                if (edit.DESCRIPTION != null)
                    status.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    status.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    status.REMARKS = edit.REMARKS;

                if (edit.ORDER != null)
                    status.ORDER = edit.ORDER;





                context.PSTATUSES.Update(status);

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