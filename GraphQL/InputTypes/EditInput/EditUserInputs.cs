using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.EditInput.EditUserInputs
{
    public record EditUserInput(
        string? FIRSTNAME,
        string? MIDDLENAME,
        string? LASTNAME,
        string? USERNAME,
        string? EMAIL,
        Guid? ROLE_ID,
        Guid? USER_ID

    );

    public record EditRoleInput(
        string? TITLE,
        Guid? ROLE_ID
    );
}