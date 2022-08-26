using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class CategoryProductDao
    {
        OnlineShopDbContext db = null;
        public CategoryProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public ProductCategory GetByID(long id)
        {
            return db.ProductCategories.Find(id);
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Updatecate(ProductCategory entity)
        {
            try
            {
                var category = db.ProductCategories.Find(entity.ID);
                category.Name = entity.Name;
                category.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public IEnumerable<ProductCategory> ListAllPagingcate(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public ProductCategory GetByIdcate(string userName)
        {
            return db.ProductCategories.SingleOrDefault(x => x.Name == userName);
        }
        public ProductCategory ViewDetailcate(int id)
        {
            return db.ProductCategories.Find(id);
        }
        public bool Deletecate(int id)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
