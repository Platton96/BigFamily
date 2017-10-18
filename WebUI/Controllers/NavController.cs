using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        private IPhotoRepository repository;
        public NavController(IPhotoRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(int userId, string album = null)
        {
            ViewBag.SelectedAlbum = album;
            IEnumerable<string> albums = repository.Photos
                .Where(x=>x.UserID==userId)
                .Select(x => x.Albom)
                .Distinct();
            ViewBag.UserId = userId;
            return PartialView(albums);
        }

    }
}
