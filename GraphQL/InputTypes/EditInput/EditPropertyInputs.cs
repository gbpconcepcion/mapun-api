using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.EditInput.EditPropertyInputs
{
    public record EditPropertyInput(
        string? PROPERTY_IDENTIFICATION_NUMBER,
        string? ARP_NO,
        string? TCT_CLOA_NO,
        string? OCT_NO,
        string? TD_NO,
        string? LOT_NO,
        string? BLOCK_NO,
        string? BOUNDARY_NORTH,
        string? BOUNDARY_SOUTH,
        string? BOUNDARY_WEST,
        string? BOUNDARY_EAST,
        string? PROPERTY_NAME,
        Instant? DATE_FILLED,
        long? PROPERTY_LONGITUDE,
        long? PROPERTY_LATITUDE,
        string? OWNER_NAME,
        string? OWNER_ADDRESS,
        string? OWNER_TIN,
        string? OWNER_TEL,
        string? ADMINISTRATOR_NAME,
        string? ADMINISTRATOR_ADDRESS,
        string? ADMINISTRATOR_TIN,
        string? ADMINISTRATOR_TEL,
        string? PROPERTY_STREET,
        string? PROPERTY_BARANGAY,
        string? PROPERTY_MUNICIPALITY,
        string? MEMORANDA,
        string? PROVINCE,
        string? EMAIL,
        Guid? PSTATUS_ID,
        Guid? PEHANCEMENT_ID,
        Guid? MRATE_ID,
        Guid? BRATE_ID,
        Guid? ZONE_ID,
        Guid? PROPERTY_ID

    );

    public record EditPEnhancementInput(
        string? DESCRIPTION,
        string? TITLE,
        string? ENHANCEMENT_TYPE,
        string? REMARKS,
        Guid? ERATE_ID,
        Guid? PEHANCMENT_ID
    );

    public record EditPLogsInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        Guid? USER_ID,
        Guid? PROPERTY_ID,
        Guid? PLOG_ID
    );

    public record EditPStatusInput(
        string? DESCRIPTION,
        string? TITLE,
        string? REMARKS,
        int? ORDER,
        Guid? PSTATUS_ID
    );
}