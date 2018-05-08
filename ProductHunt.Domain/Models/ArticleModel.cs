using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductHunt.Domain.Models
{
    public class ArticleModel : BaseModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        [RegularExpression("([a-zA-Z0-9 ]+)", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        [Required]
        public decimal PriceWithVAT { get; set; }
    }
}
