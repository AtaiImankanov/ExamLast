using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace homework_64_Atai.ViewModels
{
    public class TopUpViewModel
    {
        [Required]
        [Display(Name = "PersonalBill")]
        [Remote(action: "BillValid", controller: "Account", ErrorMessage = "Не существует")]
        public int PersonalBill { get; set; }

        [Required]
        [Display(Name = "Amount to top up")]
        public int AmountTopUp { get; set; }




    }
}
