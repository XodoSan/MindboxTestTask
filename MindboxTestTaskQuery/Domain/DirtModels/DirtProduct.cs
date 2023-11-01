namespace MindboxTestTaskQuery.Domain.DirtModels
{
    /// <summary>
    /// Грязная модель продукта
    /// </summary>
    public class DirtProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}