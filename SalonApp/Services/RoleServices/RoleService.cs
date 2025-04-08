using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalonApp.Abstractions;
using SalonApp.Contracts.Roles;
using SalonApp.Entities;
using SalonApp.Errors;
using SalonApp.Persistence;

namespace SalonApp.RoleServices.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await roleManager.Roles
            .Where(x =>  (!x.IsDeleted || includeDisabled))
            .ProjectToType<RoleResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<RoleDetailResponse>> GetAsync(string id)
    {
        if (await roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

        var permissions = await roleManager.GetClaimsAsync(role);

        var response = new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(x => x.Value));

        return Result.Success(response);
    }

}