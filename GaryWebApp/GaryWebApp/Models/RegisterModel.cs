using System;
using System.ComponentModel.DataAnnotations;

namespace GaryWebApp.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Username: ")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

		[Required]
		[Display(Name = "ConfirmPassword: ")]
		public string ConfirmPassword { get; set; }
    }
}
