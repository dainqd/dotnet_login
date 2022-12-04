using Microsoft.AspNetCore.Authorization;

namespace Auth.Controllers;

public class CustomUserRequireClaim : IAuthorizationRequirement
{
    public string ClaimType { get; }
    public CustomUserRequireClaim(string claimType)
    {
        ClaimType = claimType;
    }
}