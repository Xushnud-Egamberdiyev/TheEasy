using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEasy.Data.IRepositories;
using TheEasy.Domain.Entities;
using TheEasy.Services.DTOs.Users;
using TheEasy.Services.Exceptions;
using TheEasy.Services.Interfaces;

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

        if(result is not null)
        {
            throw new CustomException(409, "User is already exits");
        }

        var mapped = this.mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var model = await this.repository.InsertAsync(mapped);

        return this.mapper.Map<UserForResultDto>(model);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.repository.SelectByIdAsync(id);

        if(user is null)
            throw new CustomException(404, "User not found");

        await this.repository.DeleteAsync(id);
        return true;
        
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await this.repository.SelectAll().
            ToListAsync();

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

        if(model is null)
        {
            throw new CustomException(404, "User is not found");
        }

        var mapper = this.mapper.Map<User>(dto);
        mapper.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mapper);

        return this.mapper.Map<UserForResultDto>(result);

    }
}
