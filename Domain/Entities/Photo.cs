using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Photo
    {
        [HiddenInput(DisplayValue = false)]
        public int PhotoID { get; set; }
        [Required(ErrorMessage = "Please enter a  name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a  albom")]
        public string Albom { get; set; }

        [Required(ErrorMessage = "Please enter a  description")]
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        public int UserID { get; set; }

    }
}
