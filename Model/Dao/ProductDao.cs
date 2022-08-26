using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Product GetByID(long id)
        {
            return db.Products.Find(id);
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.CategoryID = entity.CategoryID;
                product.Name = entity.Name;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        // public Category GetByIContent(string Name)
        // {
        //   return db.Contents.SingleOrDefault(x => x.Name == Name);
        // }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}
