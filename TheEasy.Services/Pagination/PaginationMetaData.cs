namespace TheEasy.Services.Pagination;

public class PaginationMetaData
{

    public int CurrentPage { get; set; }       // 5
    public int TotalPages { get; set; }         //20
    public int TotalCount { get; set; }         //40
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetaData(int totalCount, PaginationParams @params)
    {
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
        CurrentPage = @params.PageIndex;
    }
}



//public class PaginationMetaData
//{
//public int CurrentPage { get; set; } // Hozirgi sahifa raqami, ya'ni foydalanuvchi qaysi sahifada turganini ko'rsatadi.
//public int TotalPages { get; set; } // Umumiy sahifalar soni, ya'ni barcha sahifalar qancha ekanligini ko'rsatadi.
//public int TotalCount { get; set; } // Umumiy elementlar soni, ya'ni barcha sahifalardagi jami elementlar sonini ko'rsatadi.

//public bool HasPrevious => CurrentPage > 1;
//// Bu xususiyat agar hozirgi sahifa 1-dan katta bo'lsa `true` qiymatini qaytaradi, ya'ni oldingi sahifaga o'tish mumkinligini bildiradi.

//public bool HasNext => CurrentPage < TotalPages;
//// Bu xususiyat agar hozirgi sahifa umumiy sahifalar sonidan kichik bo'lsa `true` qiymatini qaytaradi, ya'ni keyingi sahifaga o'tish mumkinligini bildiradi.

//public PaginationMetaData(int totalCount, PaginationParams @params)
//{
//    // PaginationMetaData konstruktor bo'lib, u sahifalash ma'lumotlarini boshlang'ich qiymatlarini o'rnatadi.

//    TotalCount = totalCount;
//    // Umumiy elementlar sonini o'rnatish (masalan, ma'lumotlar bazasidagi jami yozuvlar soni).

//    TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
//    // Umumiy sahifalar sonini hisoblash. 
//    // Bunda jami elementlar soni sahifa hajmiga bo'linadi va keyin yuqoriga qarab yaxlitlanadi.

//    CurrentPage = @params.PageIndex;
//    // Hozirgi sahifani `PaginationParams` klassidagi `PageIndex` xususiyatida berilgan qiymatga o'rnatish.
//}
//}

