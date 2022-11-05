using Microsoft.AspNetCore.Identity;
using System;

namespace homework_64_Atai.Models
{
    public class User : IdentityUser<int>
    {
        public int Balance { get; set; }
        public int PersonalBill { get; set; }
    }
}
