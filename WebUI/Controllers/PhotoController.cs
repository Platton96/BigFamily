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

        public ViewResult Albums(int userId)
        {

            PhotoModelView photosUser = new PhotoModelView
            {
                Photos = repository.Photos
                .Where(p => p.UserID == userId)
                .OrderBy(p => p.Name)

            };
                   
             
            return View(photosUser);
               
        }
    }
}
