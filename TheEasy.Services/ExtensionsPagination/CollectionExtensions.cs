using Newtonsoft.Json;
using TheEasy.Domain.Commans;
using TheEasy.Services.Exceptions;
using TheEasy.Services.Helpers;
using TheEasy.Services.Pagination;

namespace TheEasy.Services.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
            where TEntity : Auditable
        {

            var metaData = new PaginationMetaData(source.Count(), @params);

            var json = JsonConvert.SerializeObject(metaData);
            if (HttpContextHelper.ResponseHeaders != null)
            {
                if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
                    HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

                HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);
            }

            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                source
                .OrderBy(s => s.Id)
                .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
                : throw new CustomException(400, "Please, enter valid numbers");
        }

        public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> source, PaginationParams @params)
        {
            if (@params.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
            }

            if (@params.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
            }

            return source.Take((@params.PageSize * (@params.PageIndex - 1))..(@params.PageSize * (@params.PageIndex - 1) + @params.PageSize));
        }

    }
}

//public static class CollectionExtensions
//{
//    // IQueryable turlari uchun kengaytirish metodi
//    public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
//        where TEntity : Auditable
//    {
//        // source.Count() bilan umumiy elementlar soni asosida PaginationMetaData ob'ekti yaratilyapti
//        var metaData = new PaginationMetaData(source.Count(), @params);

//        // MetaData ni JSON formatida saqlash
//        var json = JsonConvert.SerializeObject(metaData);

//        // Agar ResponseHeaders mavjud bo'lsa
//        if (HttpContextHelper.ResponseHeaders != null)
//        {
//            // "X-Pagination" kalit mavjud bo'lsa, uni olib tashlaymiz
//            if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
//                HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

//            // So'ngra, yangi "X-Pagination" kalit bilan JSON ma'lumotlarni qo'shamiz
//            HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);
//        }

//        // Sahifalash uchun asosiy logika
//        return @params.PageIndex > 0 && @params.PageSize > 0 ?
//            source
//            .OrderBy(s => s.Id) // ID bo'yicha saralash
//            .Skip((@params.PageIndex - 1) * @params.PageSize) // Keraksiz sahifalarni tashlab o'tish
//            .Take(@params.PageSize) // Faqat kerakli sahifadagi elementlarni olish
//            : throw new CustomException(400, "Please, enter valid numbers");
//        // Agar PageIndex yoki PageSize noto'g'ri bo'lsa, xato qaytarish
//    }

//    // IEnumerable turlari uchun kengaytirish metodi
//    public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> source, PaginationParams @params)
//    {
//        // Agar PageIndex 1 dan kichik bo'lsa, xatolik chiqarish
//        if (@params.PageIndex < 1)
//        {
//            throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
//        }

//        // Agar PageSize 1 dan kichik bo'lsa, xatolik chiqarish
//        if (@params.PageSize < 1)
//        {
//            throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
//        }

//        // Sahifalashni amalga oshirish
//        return source.Take((@params.PageSize * (@params.PageIndex - 1))..(@params.PageSize * (@params.PageIndex - 1) + @params.PageSize));
//        // Belgilangan sahifadagi elementlarni olish
//    }
//}

