using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddAssesmentInputs;
using mapun_api.GQL.InputTypes.EditInput.EditAssesmentInputs;
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
        public async Task<Response> AddAssessmentAsync(
            AddAssessmentInput input,
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
                var assessment = new mapun_api.Models.Entities.Assessment
                {
                    ARP_NO = input.ARP_NO,
                    TCT_CLOA_NO = input.TCT_CLOA_NO,
                    OCT_NO = input.OCT_NO,
                    TD_NO = input.TD_NO,
                    DATE_FILLED = input.DATE_FILLED,
                    SURVEY_NO = input.SURVEY_NO,
                    ASSESSED_BOUNDARY_NORTH = input.ASSESSED_BOUNDARY_NORTH,
                    ASSESSED_BOUNDARY_SOUTH = input.ASSESSED_BOUNDARY_SOUTH,
                    ASSESSED_BOUNDARY_WEST = input.ASSESSED_BOUNDARY_WEST,
                    ASSESSED_BOUNDARY_EAST = input.ASSESSED_BOUNDARY_EAST,
                    MEMORANDA = input.MEMORANDA,
                    PROPERTY_ID = input.PROPERTY_ID,
                    IS_ACTIVE = true,


                };

                context.ASSESSMENTS.Add(assessment);

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
        public async Task<Response> EditAStatusAsync(
            EditAssessmentInput edit,
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
                var assessment = await context.FindAsync<Assessment>(edit.ASSESSMENT_ID);

                if (edit.ARP_NO != null)
                    assessment.ARP_NO = edit.ARP_NO;

                if (edit.TCT_CLOA_NO != null)
                    assessment.TCT_CLOA_NO = edit.TCT_CLOA_NO;

                if (edit.ARP_NO != null)
                    assessment.ARP_NO = edit.ARP_NO;

                if (edit.OCT_NO != null)
                    assessment.OCT_NO = edit.OCT_NO;

                if (edit.TD_NO != null)
                    assessment.TD_NO = edit.TD_NO;

                if (edit.DATE_FILLED != null)
                    assessment.DATE_FILLED = edit.DATE_FILLED;

                if (edit.SURVEY_NO != null)
                    assessment.SURVEY_NO = edit.SURVEY_NO;

                if (edit.ASSESSED_BOUNDARY_NORTH != null)
                    assessment.ASSESSED_BOUNDARY_NORTH = edit.ASSESSED_BOUNDARY_NORTH;

                if (edit.ASSESSED_BOUNDARY_SOUTH != null)
                    assessment.ASSESSED_BOUNDARY_SOUTH = edit.ASSESSED_BOUNDARY_SOUTH;

                if (edit.ASSESSED_BOUNDARY_WEST != null)
                    assessment.ASSESSED_BOUNDARY_WEST = edit.ASSESSED_BOUNDARY_WEST;

                if (edit.ASSESSED_BOUNDARY_EAST != null)
                    assessment.ASSESSED_BOUNDARY_EAST = edit.ASSESSED_BOUNDARY_EAST;

                if (edit.MEMORANDA != null)
                    assessment.MEMORANDA = edit.MEMORANDA;

                if (edit.PROPERTY_ID != null)
                    assessment.PROPERTY_ID = edit.PROPERTY_ID;




                context.ASSESSMENTS.Update(assessment);

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