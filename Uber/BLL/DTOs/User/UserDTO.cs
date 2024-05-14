using System;
using System.Collections.Generic;

namespace BLL.DTOs.User
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        // Other user details as needed
        public virtual ICollection<PaymentDTO> Payments { get; set; }
    }
}
