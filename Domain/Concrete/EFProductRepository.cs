using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFProductRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserID);
                if(dbEntry!=null)
                {
                    dbEntry.Name = user.Name;
                    dbEntry.Surname = user.Surname;
                    dbEntry.Email = user.Email;
                    dbEntry.Password = user.Password;
                    dbEntry.Burthday = user.Burthday;
                    dbEntry.NumberPhone = user.NumberPhone;
                    dbEntry.ImageData = user.ImageData;
                    dbEntry.ImageMimeType = user.ImageMimeType;

                }
            }
            context.SaveChanges();
        }
        public User DeleteUser(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry!=null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
