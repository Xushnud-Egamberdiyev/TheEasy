using Microsoft.AspNetCore.Mvc;
using TheEasy.Api.Models;
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
        => Ok(new Response
        {
            StutusCode = 200,
            Message = "OK",
            Data = await this.userService.RetrieveAllAsync()
        });
        
  

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(long id)
       => Ok(new Response
       {
           StutusCode = 200,
           Message = "OK",
           Data = await this.userService.RetrieveByIdAsync(id)
       });

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserForCreationDto dto)
     => Ok(new Response
     {
         StutusCode = 200,
         Message = "OK",
         Data = await this.userService.CreateAsync(dto)
     });

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UserForUpdateDto dto)
      => Ok(new Response
      {
          StutusCode = 200,
          Message = "OK",
          Data = await this.userService.UpdateAsync(dto)
      });

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id)
      => Ok(new Response
      {
          StutusCode = 200,
          Message = "OK",
          Data = await this.userService.RemoveAsync(id)
      });
}
