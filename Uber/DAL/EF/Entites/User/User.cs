using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.EF.Entities.User; // Import the namespace containing the Payment_u entity

namespace DAL.EF.Entities.User
{
    public class UserEF
    {
        [Key]
        public int UserID { get; set; } // Primary Key

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        // Other user details as needed

        // Navigation property
        public virtual ICollection<Payment_u> Payments { get; set; }
    }
}
