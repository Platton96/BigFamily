using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;
namespace WebUI.Controllers
{
    public class SliderController : Controller
    {
        //
        // GET: /Slider/
        private IPhotoRepository repository;
        public SliderController(IPhotoRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult SliderOfPhoto(int userId)
        {
            PhotoModelView photo = new PhotoModelView
            {
                Photos=repository.Photos
                .Where(p=>p.UserID==userId)
            };
            
            return PartialView(photo);
        }

    }
}
