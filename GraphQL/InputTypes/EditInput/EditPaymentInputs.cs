using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.EditInput.EditPaymentInputs
{
    public record EditPaymentInput(
        string? TRANSACTION_CODE,
        string? TITLE,
        string? REMARKS,
        string? PAYER_NAME_PROXY,
        Instant? DUE_DATE,
        long? AMOUNT_DUE,
        Guid? PAYSTATUS_ID,
        Guid? PROPERTY_ID,
        Guid? PAYMENT_ID

    );

    public record EditPayStatusInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        Instant? DUE_DATE,
        int? ORDER,
        Guid? PAYSTATUS_ID
    );
}