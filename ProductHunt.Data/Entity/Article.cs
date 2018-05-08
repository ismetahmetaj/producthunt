using System.ComponentModel.DataAnnotations.Schema;

namespace ProductHunt.Data.Entity
{
    public class Article : BaseEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public decimal PriceWithVAT { get; set; }
        public decimal Price { get; set; }
    }
}