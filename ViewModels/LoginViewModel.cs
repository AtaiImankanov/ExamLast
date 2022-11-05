using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace homework_64_Atai.ViewModels
{
    public class LoginViewModel
    {
        [Required]

        [Display(Name = "Personal Bill")]
        public int PersonalBill { get; set; }



        [Required]

        [DataType(DataType.Password)]

        [Display(Name = "Пароль")]

        public string Password { get; set; }



        [Display(Name = "Запомнить?")]

        public bool RememberMe { get; set; }



        public string ReturnUrl { get; set; }
    }
}
