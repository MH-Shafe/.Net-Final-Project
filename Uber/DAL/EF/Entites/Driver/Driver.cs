using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DAL.EF.Entities.Driver

{
    public class DriverEF
    {
        [Key]
        public int UserID { get; set; } // Primary Key       
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation property for payments
        public virtual ICollection<Payment> Payments { get; set; }
    }
}