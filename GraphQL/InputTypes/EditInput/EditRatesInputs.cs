using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.EditInput.EditRatesInputs
{
    public record EditBRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE,
        Guid? BRATE_ID

    );

    public record EditMRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE,
        Guid? MRATE_ID
    );

    public record EditERateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE,
        Guid? ERATE_ID
    );

    public record EditZRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE,
        Guid? ZRATE_ID
    );
}