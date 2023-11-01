using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindboxTestTaskQuery.Domain.Repositories;
using MindboxTestTaskQuery.Infrastructure;
using MindboxTestTaskQuery.Infrastructure.Helpers;

public class Program
{
    //Configure services
    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();

        string rootUrl = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString();
        IConfiguration config = GetConfigByUrl(rootUrl);
        string connectionString = config.GetConnectionString("default");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    //Entry point
    private static void Main(string[] args)
    {
        //Не понятно это задание по контексту.
        //Сложность задания вырастает, если будет только две таблицы и в их строках должны быть связующие данные
        //Но в таком случае база будет не нормализованной и совершенно некорректной
        //Я предполагаю, что модели, если следовать логике постановки задачи, должны выглядеть так:
        //Product - Id, Name, ProductId, CategoryId;   Category - Id, Name, ProductId, CategoryId, если я правильно понял
        //В своём решении я сделаю по-нормальному и по ТЗ

        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();
        var repository = serviceProvider.GetService<ICategoryProductRepository>();
        var uiHelper = new UIHelper(73);

        var resultDirt = repository.GetProductCategoryNamesByDirt();
        var resultClear = repository.GetProductCategoryNamesByClear();

        Console.WriteLine("Данные могут отличаться, так как таблицы разные, заполнялись вручную");
        Console.WriteLine("Table by dirt models: ");
        uiHelper.PrintLine();
        uiHelper.PrintRow("Product", "Category");
        uiHelper.PrintLine();
        foreach (var elementDirt in resultDirt)
        {
            uiHelper.PrintRow(elementDirt.ProductName, elementDirt.CategoryName);
            uiHelper.PrintLine();
        }


        Console.WriteLine("Table by clear models: ");
        uiHelper.PrintLine();
        uiHelper.PrintRow("Product", "Category");
        uiHelper.PrintLine();
        foreach (var elementClear in resultClear)
        {
            uiHelper.PrintRow(elementClear.ProductName, elementClear.CategoryName);
            uiHelper.PrintLine();
        }
    }

    //Creating DbContext
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string rootUrl = Directory.GetCurrentDirectory();
            IConfiguration config = GetConfigByUrl(rootUrl);
            string connectionString = config.GetConnectionString("default");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }

    private static IConfiguration GetConfigByUrl(string rootUrl)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(rootUrl)
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}