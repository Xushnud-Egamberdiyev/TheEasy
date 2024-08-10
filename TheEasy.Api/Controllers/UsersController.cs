using Microsoft.AspNetCore.Mvc;
using TheEasy.Services.DTOs.Users;
using TheEasy.Services.Interfaces;

namespace TheEasy.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService) =>
        this.userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var user = userService.RetrieveAllAsync();
        
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var user = await this.userService.RetrieveByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserForCreationDto dto)
    {
        var user = await this.userService.CreateAsync(dto);

        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await this.userService.UpdateAsync(dto);

        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var user = await this.userService.RemoveAsync(id);

        return Ok(user);
    }
}
