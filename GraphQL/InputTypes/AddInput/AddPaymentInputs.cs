using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.AddInput.AddPaymentInputs
{
    public record AddPaymentInput(
        string? TRANSACTION_CODE,
        string? TITLE,
        string? REMARKS,
        string? PAYER_NAME_PROXY,
        Instant? DUE_DATE,
        long? AMOUNT_DUE,
        Guid? PAYSTATUS_ID,
        Guid? PROPERTY_ID

    );

    public record AddPayStatusInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        int? ORDER
    );
}