namespace MindboxTestTaskQuery.Domain.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Знаю про аннотации, ради соблюдения хорошего тона разработки поместил все конфигурации в одно место - AppDbContext
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryProduct>? CategoryProducts { get; set; }
    }
}