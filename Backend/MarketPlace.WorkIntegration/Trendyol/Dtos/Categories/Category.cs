using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.WorkIntegration.Trendyol.Dtos.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object ParentId { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
