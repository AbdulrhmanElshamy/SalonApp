using Microsoft.AspNetCore.Authorization;

namespace SalonApp.Authentication.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
}