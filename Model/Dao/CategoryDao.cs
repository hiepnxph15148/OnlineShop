using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Updatecate(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
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

      

        public IEnumerable<Category> ListAllPagingcate(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Category GetByIdcate(string userName)
        {
            return db.Categories.SingleOrDefault(x => x.Name == userName);
        }
        public Category ViewDetailcate(int id)
        {
            return db.Categories.Find(id);
        }
        public bool Deletecate(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
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
