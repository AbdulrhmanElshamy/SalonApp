using Microsoft.AspNetCore.Authorization;

namespace SalonApp.Authentication.Filters;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}