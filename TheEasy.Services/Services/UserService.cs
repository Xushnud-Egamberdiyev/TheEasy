using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheEasy.Data.IRepositories;
using TheEasy.Domain.Entities;
using TheEasy.Services.DTOs.Users;
using TheEasy.Services.Exceptions;
using TheEasy.Services.Extensions;
using TheEasy.Services.Interfaces;
using TheEasy.Services.Pagination;

namespace TheEasy.Services.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        this.repository = userRepository;
        this.mapper = mapper;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var result = await this.repository.SelectAll().
            FirstOrDefaultAsync(e => e.Email.ToLower() == dto.Email.ToLower());

        if (result is not null)
        {
            throw new CustomException(409, "User is already exits");
        }

        var mapped = this.mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var model = await this.repository.InsertAsync(mapped);

        await this.repository.SacheChangAsync();

        return this.mapper.Map<UserForResultDto>(model);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.repository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User not found");

        await this.repository.DeleteAsync(id);
        await this.repository.SacheChangAsync();

        return true;

    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await repository.SelectAll().
            ToPagedList(@params)
            .ToListAsync();
        return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.repository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found");

        return this.mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var model = await this.repository.SelectByIdAsync(dto.Id);

        if (model is null)
        {
            throw new CustomException(404, "User is not found");
        }

        var mapper = this.mapper.Map(dto, model);
        mapper.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mapper);

        await this.repository.SacheChangAsync();


        return this.mapper.Map<UserForResultDto>(result);

    }
}
