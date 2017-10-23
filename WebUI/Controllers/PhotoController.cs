using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PhotoController : Controller
    {
        private IPhotoRepository repository;
        public PhotoController(IPhotoRepository repo)
        {
            this.repository=repo;
        }
        //
        // GET: /Photo/

        public ViewResult Albums(int userId, string album)
        {
            

            PhotoModelView photosUser = new PhotoModelView
            {
                Photos = repository.Photos
                .Where(p => p.UserID == userId&&(album==null||p.Albom==album))
                .OrderBy(p => p.Name),
                CurrentAlbum=album

            };

            ViewBag.UserId = userId;
                   
             
            return View(photosUser);
        }
        public ViewResult AddNewPhoto(int userId)
        {
            return View(new Photo());
        }
        [HttpPost]
        public ActionResult AddNewPhoto(Photo photoUser, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photoUser.ImageMimeType = image.ContentType;
                    photoUser.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(photoUser.ImageData, 0, image.ContentLength);
                }
                repository.SavePhoto(photoUser);
                return RedirectToAction("Albums", new { userId=photoUser.UserID });
            }
            else
            {
                return View(photoUser);
            }
        }

        public FileContentResult GetPhoto(int photoId)
        {
            Photo photo = repository.Photos.FirstOrDefault(ph => ph.PhotoID == photoId);
            if (photo!=null)
            {
                return File(photo.ImageData, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
