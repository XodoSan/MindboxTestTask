using Microsoft.EntityFrameworkCore;
using MindboxTestTaskQuery.Infrastructure;

namespace MindboxTestTaskQuery.Domain.Repositories
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
        private readonly AppDbContext _context;

        public CategoryProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Получение пар имён продукт-категория по-грязному
        /// </summary>
        /// <returns></returns>
        public List<CategoryProductDto> GetProductCategoryNamesByDirt()
        {
            //Так как в ТЗ написано "Напишите запрос", воспользуюсь сырым SQL 
            //Для реализации использую LINQ
            //Сырой SQL запрос
            // SELECT DISTINCT DirtProducts.Name AS ProductName,
            // DirtCategories.Name AS CategoryName
            // FROM DirtProducts LEFT JOIN DirtCategories ON DirtProducts.CategoryId = DirtCategories.CategoryId

            return (from p in _context.DirtProducts
                        join c in _context.DirtCategories
                        on p.CategoryId equals c.CategoryId into lJ
                        from res in lJ.DefaultIfEmpty()
                        select new CategoryProductDto
                        {
                            CategoryName = res.Name == null ? " " : res.Name, //Чтобы не обваливалось при построении таблицы в UI
                            ProductName = p.Name,
                        })
                        .Distinct()
                        .ToList();
        }

        /// <summary>
        /// Получение пар имён продукт-категория по-чистому
        /// </summary>
        /// <returns></returns>
        public List<CategoryProductDto> GetProductCategoryNamesByClear()
        {
            //Сырой SQL запрос
            // SELECT Products.Name AS ProductName,
            // Categories.Name AS CategoryName FROM CategoryProduct
            // LEFT JOIN Categories ON CategoryProduct.CategoryId = Categories.Id
            // LEFT JOIN Products ON CategoryProduct.ProductId = Products.Id

            return (from cp in _context.CategoryProduct
                    join c in _context.Categories
                    on cp.CategoryId equals c.Id into lJ
                    from res1 in lJ.DefaultIfEmpty()
                    join p in _context.Products
                    on cp.ProductId equals p.Id into lJ2
                    from res2 in lJ2.DefaultIfEmpty()
                    select new CategoryProductDto
                    {
                        CategoryName = res1.Name == null ? " " : res1.Name, //Чтобы не обваливалось при построении таблицы в UI
                        ProductName = res2.Name,
                    })
                    .ToList();
        }
    }
}