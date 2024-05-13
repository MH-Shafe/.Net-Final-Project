using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Admin
{
    public class SignUpDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public List<LoginDTO> Logins { get; set; } // Add Logins to represent the one-to-many relationship

    }
}
