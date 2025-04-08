using SalonApp.Abstractions;
using SalonApp.Contracts.Roles;

namespace SalonApp.RoleServices.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailResponse>> GetAsync(string id);
}