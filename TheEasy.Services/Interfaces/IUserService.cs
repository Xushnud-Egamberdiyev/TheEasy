using TheEasy.Services.DTOs.Users;
using TheEasy.Services.Pagination;

namespace TheEasy.Services.Interfaces;

public interface IUserService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
