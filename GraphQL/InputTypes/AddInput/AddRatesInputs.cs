using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.AddInput.AddRatesInputs
{
    public record AddBRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE

    );

    public record AddMRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE
    );

    public record AddERateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE
    );

    public record AddZRateInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        long? RATE
    );
}