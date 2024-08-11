using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEasy.Services.Helpers;

namespace TheEasy.Shared.Extensions;

public static class HttpContextExtensions
{
    public static void InitAccessor(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        HttpContextHelper.Accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
    }
}
