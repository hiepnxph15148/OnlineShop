using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;
namespace Model.Dao
{
    
    public class ContentDao
    {
        OnlineShopDbContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool DeleteContent(int id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
        public bool UpdateContent(Content entity)
        {
            try
            {
                var content = db.Contents.Find(entity.ID);
                content.CategoryID = entity.CategoryID;
                content.Name = entity.Name;
                content.Image = entity.Image;
                content.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public IEnumerable<Content> ListAllPagingContent(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
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
        public Content ViewDetailContent(int id)
        {
            return db.Contents.Find(id);
        }
    }
}
