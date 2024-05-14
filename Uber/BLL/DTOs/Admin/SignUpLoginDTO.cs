using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Admin
{
    public class SignUpLoginDTO
    {
        public SignUpDTO SignUp_D { get; set; }
        public LoginDTO Login { get; set; }
    }
}
