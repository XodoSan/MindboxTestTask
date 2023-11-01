namespace MindboxTestTaskQuery.Domain.DirtModels
{
    /// <summary>
    /// Грязная модель категории
    /// </summary>
    public class DirtCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
    }
}