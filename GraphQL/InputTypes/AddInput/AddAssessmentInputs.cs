using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.AddInput.AddAssesmentInputs
{
    public record AddAssessmentInput(
        string? ARP_NO,
        string? TCT_CLOA_NO,
        string? OCT_NO,
        string? TD_NO,
        Instant? DATE_FILLED,
        string? SURVEY_NO,
        string? ASSESSED_BOUNDARY_NORTH,
        string? ASSESSED_BOUNDARY_SOUTH,
        string? ASSESSED_BOUNDARY_WEST,
        string? ASSESSED_BOUNDARY_EAST,
        string? MEMORANDA,
        Guid? PROPERTY_ID

    );
}