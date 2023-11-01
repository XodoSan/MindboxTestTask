namespace MindboxTestTaskQuery.Domain.Models
{
    /// <summary>
    /// Связующая таблица между продуктом и категорией
    /// </summary>
    public class CategoryProduct
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Знаю про аннотации, ради соблюдения хорошего тона разработки поместил все конфигурации в одно место - AppDbContext
        public int Id { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}