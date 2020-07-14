using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
   
   public class UserDao
    {
        MobileShopDbContext db = null;
        public UserDao()
        {
            db = new MobileShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //hien thi User
        public IEnumerable<User> ListAllPaing(int page, int pageSize)
        {
           
            return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pageSize);
        }

        public User GetById (string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login (string username ,string password )
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == username );
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false){
                    return -1;

                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
