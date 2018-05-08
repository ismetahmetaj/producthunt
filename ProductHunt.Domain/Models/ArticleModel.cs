using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductHunt.Domain.Models
{
    public class ArticleModel : BaseModel
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithVAT { get; set; }
    }
}
