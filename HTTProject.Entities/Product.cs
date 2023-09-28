using System.ComponentModel.DataAnnotations.Schema;

namespace HTTProject.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int CategoryId { get; set; }

    }
}