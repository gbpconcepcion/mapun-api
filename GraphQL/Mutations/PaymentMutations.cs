using mapun_api.Models.Entities;
using mapun_api.GQL.InputTypes.AddInput.AddPaymentInputs;
using mapun_api.GQL.InputTypes.EditInput.EditPaymentInputs;
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
        public async Task<Response> AddPaymentAsync(
            AddPaymentInput input,
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
                var payment = new mapun_api.Models.Entities.Payment
                {
                    TRANSACTION_CODE = input.TRANSACTION_CODE,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    PAYER_NAME_PROXY = input.PAYER_NAME_PROXY,
                    DUE_DATE = input.DUE_DATE,
                    AMOUNT_DUE = input.AMOUNT_DUE,
                    PAYSTATUS_ID = input.PAYSTATUS_ID,
                    PROPERTY_ID = input.PROPERTY_ID,
                    IS_ACTIVE = true,


                };

                context.PAYMENTS.Add(payment);

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
        public async Task<Response> EditPaymentAsync(
            EditPaymentInput edit,
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
                var payment = await context.FindAsync<Payment>(edit.PAYMENT_ID);

                if (edit.TRANSACTION_CODE != null)
                    payment.TRANSACTION_CODE = edit.TRANSACTION_CODE;

                if (edit.TITLE != null)
                    payment.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    payment.REMARKS = edit.REMARKS;

                if (edit.PAYER_NAME_PROXY != null)
                    payment.PAYER_NAME_PROXY = edit.PAYER_NAME_PROXY;

                if (edit.DUE_DATE != null)
                    payment.DUE_DATE = edit.DUE_DATE;

                if (edit.AMOUNT_DUE != null)
                    payment.AMOUNT_DUE = edit.AMOUNT_DUE;

                if (edit.PAYSTATUS_ID != null)
                    payment.PAYSTATUS_ID = edit.PAYSTATUS_ID;

                if (edit.PROPERTY_ID != null)
                    payment.PROPERTY_ID = edit.PROPERTY_ID;




                context.PAYMENTS.Update(payment);

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
        public async Task<Response> AddPayStatusAsync(
            AddPayStatusInput input,
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
                var paystatus = new mapun_api.Models.Entities.PaymentStatus
                {
                    DESCRIPTION = input.DESCRIPTION,
                    TITLE = input.TITLE,
                    REMARKS = input.REMARKS,
                    ORDER = input.ORDER,
                    IS_ACTIVE = true,


                };

                context.PAYSTATUSES.Add(paystatus);

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
        public async Task<Response> EditPayStatusAsync(
            EditPayStatusInput edit,
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
                var paystatus = await context.FindAsync<PaymentStatus>(edit.PAYSTATUS_ID);

                if (edit.DESCRIPTION != null)
                    paystatus.DESCRIPTION = edit.DESCRIPTION;

                if (edit.TITLE != null)
                    paystatus.TITLE = edit.TITLE;

                if (edit.REMARKS != null)
                    paystatus.REMARKS = edit.REMARKS;

                if (edit.ORDER != null)
                    paystatus.ORDER = edit.ORDER;





                context.PAYSTATUSES.Update(paystatus);

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