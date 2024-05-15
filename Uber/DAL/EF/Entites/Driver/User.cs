using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Entities.User
{
    public class UserEF
    {
        [Key]
        public int UserID { get; set; } // Primary Key       
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
