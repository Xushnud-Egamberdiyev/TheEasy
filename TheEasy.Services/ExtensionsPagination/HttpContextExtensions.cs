//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using TheEasy.Services.Helpers;


//namespace TheEasy.Services.ExtensionsPagination
//{
//    public static class HttpContextExtensions
//    {
//        public static void InitAccessor(this WebApplication app)
//        {
//            using var scope = app.Services.CreateScope();

//            HttpContextHelper.Accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
//        }
//    }
//}
