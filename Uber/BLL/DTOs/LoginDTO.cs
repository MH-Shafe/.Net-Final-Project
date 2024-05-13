using BLL.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roll { get; set; }
        public int SignUpId { get; set; } // Add SignUpId to maintain the relationship
        public SignUpDTO SignUp { get; set; } // Add SignUp DTO
    }
}
