using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFPhotoRepository:IPhotoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Photo> Photos
        {
            get {return context.Photos;}
        }
        public void SavePhoto(Photo photo)
        {
            if(photo.PhotoID==0)
            {
                context.Photos.Add(photo);
            }
            else
            {
                Photo dbEntry = context.Photos.Find(photo.PhotoID);
                if(dbEntry!=null)
                {
                    dbEntry.Name = photo.Name;
                    dbEntry.PhotoID = photo.PhotoID;
                    dbEntry.UserID = photo.UserID;
                    dbEntry.ImageData = photo.ImageData;
                    dbEntry.ImageMimeType = photo.ImageMimeType;
                    dbEntry.Albom = photo.Albom;
                    dbEntry.Description = photo.Description;
                }
            }
            context.SaveChanges();
        }
        public Photo DeletePhoto(int photoId)
        {
            Photo dbEntry = context.Photos.Find(photoId);
            if (dbEntry!=null)
            {
                context.Photos.Remove(dbEntry);
                context.SaveChanges();
                
            }
            return dbEntry;
        }
            
    }
}
