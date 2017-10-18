using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class PhotoModelView
    {
        public IEnumerable<Photo> Photos { get; set; }
        public string CurrentAlbum { get; set; }
    }
}