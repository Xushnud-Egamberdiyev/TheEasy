using Microsoft.AspNetCore.Http;

namespace TheEasy.Services.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders = HttpContext?.Response?.Headers;
    public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;
    private static long _tempUserId;

}

//public static IHttpContextAccessor Accessor { get; set; }
//// Statik xususiyat, bu `IHttpContextAccessor` interfeysining instansiyasini saqlaydi.
//// `IHttpContextAccessor` foydalanuvchining joriy HTTP kontekstiga (`HttpContext`) kirish imkonini beradi.

//public static HttpContext HttpContext => Accessor?.HttpContext;
//// `HttpContext` xususiyati, bu joriy HTTP kontekstini olish uchun ishlatiladi.
//// Agar `Accessor` null bo'lsa, `HttpContext` null qaytaradi.

//public static IHeaderDictionary ResponseHeaders = HttpContext?.Response?.Headers;
//// `ResponseHeaders` xususiyati, bu joriy HTTP javobi (response) sarlavhalarini saqlaydi.
//// Agar `HttpContext` yoki `Response` null bo'lsa, `ResponseHeaders` null bo'ladi.

//public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;
//// `UserId` xususiyati, bu joriy foydalanuvchining ID raqamini olishga harakat qiladi.
//// `HttpContext` orqali foydalanuvchining birinchi "id" sifatidagi da'vosini (claim) topadi va uni long tipiga o'giradi.
//// Agar o'girish muvaffaqiyatli bo'lsa, `UserId` qiymatini qaytaradi; aks holda, null qaytaradi.

//private static long _tempUserId;
//// Bu xususiyati, `UserId` ni olish jarayonida vaqtincha `long` qiymatni saqlash uchun ishlatiladi.

