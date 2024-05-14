using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites.Driver
{
    public class SignUp_D
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public string Phone_Number { get; set; }

    }
}
