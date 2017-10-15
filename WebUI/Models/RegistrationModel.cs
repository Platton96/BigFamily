using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebUI.Models
{
    public class RegistrationModel
    {

        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter a  name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a  surnamename")]
        public string Surname { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Please enter a  emai")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password ")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Burthday { get; set; }
        [Required(ErrorMessage = "Please enter the number phone ")]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public  string ConfirmPassword { get; set; }
    }
}
