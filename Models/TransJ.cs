using System;

namespace homework_64_Atai.Models
{
    public class TransJ
    {
        public int Id { get; set; }
        public DateTime dateCreated { get; set; }
        public int amountOfTrans { get; set; }
        
        public int WhoSendId { get; set; }
        public User WhoSend { get; set; }

        public int WhoGetId { get; set; }
        public User WhoGet { get; set; }
 
    }
}
