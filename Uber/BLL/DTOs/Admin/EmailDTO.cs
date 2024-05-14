using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Admin
{
    public class EmailDTO
    {
        public int ID { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        
        public string Subject { get; set; }

        public string Body { get; set; }

        
        public DateTime Timestamp { get; set; }
    }
}
