using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace homework_64_Atai.ViewModels
{

        public class RegisterViewModel
        {

            [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }

        }

}
