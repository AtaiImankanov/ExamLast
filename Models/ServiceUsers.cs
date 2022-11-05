namespace homework_64_Atai.Models
{
    public class ServiceUsers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int ServiceId { get; set; }
        public ServiceCompany Service { get; set; }
    }
}
