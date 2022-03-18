using System;
using NodaTime;

namespace mapun_api.GQL.InputTypes.AddInput.AddUserInputs
{
    public record AddUserInput(
        string? FIRSTNAME,
        string? MIDDLENAME,
        string? LASTNAME,
        string? USERNAME,
        string? EMAIL,
        Guid? ROLE_ID

    );

    public record AddRoleInput(
        string? TITLE
    );
}