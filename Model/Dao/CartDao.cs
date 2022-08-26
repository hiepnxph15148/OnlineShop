using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CartDao
    {
        OnlineShopDbContext db = null;
        public CartDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListFeatureProducts3()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        }
    }
}
