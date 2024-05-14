using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites.Admin
{
    public class Email
    {
        
        public int ID { get; set; }

        
        public string Sender { get; set; }

        
        public string Recipient { get; set; }

        
        public string Subject { get; set; }

        public string Body { get; set; }

        
        public DateTime Timestamp { get; set; }
    }
}
