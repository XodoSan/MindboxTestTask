namespace MindboxTestTaskQuery.Domain.Repositories
{
    public interface ICategoryProductRepository
    {
        public List<CategoryProductDto> GetProductCategoryNamesByDirt();
        public List<CategoryProductDto> GetProductCategoryNamesByClear();
    }
}