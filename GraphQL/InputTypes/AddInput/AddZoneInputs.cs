using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.AddInput.AddZoneInputs
{
    public record AddZoneInput(
        string? ZONE_NAME,
        string? ZONE_DESCRIPTION,
        string? ZONE_AREA,
        string? ZONE_AREACODE,
        long? ZONE_LATITUDE,
        long? ZONE_LONGITUDE,
        Guid? ZRATE_ID

    );

}