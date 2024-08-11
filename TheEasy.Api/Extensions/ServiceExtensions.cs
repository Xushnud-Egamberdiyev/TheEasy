using TheEasy.Data.IRepositories;
using TheEasy.Data.Repositories;
using TheEasy.Services.Interfaces;
using TheEasy.Services.Services;

namespace TheEasy.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    }

}
