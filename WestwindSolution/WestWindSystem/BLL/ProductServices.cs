using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestwindContext _dbContext;

        public List<Product> FindProductsByCategoryId(int categoryId)
        {
            var query = _dbContext.Products.Where(item => item.CategoryId == categoryId);
            return query.ToList();
        }
    }
}
