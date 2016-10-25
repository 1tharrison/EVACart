using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EVACart.Models
{
    public class ContactViewModel
    {
        public int ContactViewModelId { get; set; }
        [Required(ErrorMessage = "You Must Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Required")]
        [RegularExpression(@"^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,11}$",
            ErrorMessage = "Please enter a valid email address.  Ex: You@YourDomain.Com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Required")]

        public string Subject { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "* Required")]
        [StringLength(500, ErrorMessage = "Please limit your response to no more than 500 characters.")]
        public string Message { get; set; }
    }
}