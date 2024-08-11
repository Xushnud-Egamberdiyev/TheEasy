namespace TheEasy.Services.Pagination;

public class PaginationParams
{
    // Sahifa o'lchami uchun maksimal qiymat (20 dan oshmasligi kerak)
    private const int _maxPageSize = 20;

    // Sahifa o'lchamini saqlash uchun xususiy o'zgaruvchi
    private int _pageSize;

    // Sahifa o'lchami uchun xususiyat
    public int PageSize
    {
        // `set` metodi - agar berilgan qiymat `_maxPageSize` (20) dan katta bo'lsa, `_pageSize` ni `20` ga o'rnatadi.
        // Aks holda, `_pageSize` ni kiritilgan qiymatga o'rnatadi.
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;

        // `get` metodi - agar `_pageSize` hali o'rnatilmagan yoki 0 bo'lsa, uni 10 ga o'rnatadi va qaytaradi.
        // Aks holda, `_pageSize` ning hozirgi qiymatini qaytaradi.
        get => _pageSize == 0 ? 10 : _pageSize;
    }

    // Sahifa indeksi uchun xususiyat - qaysi sahifa hozirgi vaqtda ko'rsatilayotgani. Standart qiymat 1.
    public int PageIndex { get; set; } = 1;

}
