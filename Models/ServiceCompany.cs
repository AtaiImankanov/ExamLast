using System.Collections.Generic;

namespace homework_64_Atai.Models
{
    public class ServiceCompany
    {
        public int Id { get; set; } 
        public int PriceService { get; set; }
        public List<ServiceUsers> ServiceUsers { get; set; }
    }
}
