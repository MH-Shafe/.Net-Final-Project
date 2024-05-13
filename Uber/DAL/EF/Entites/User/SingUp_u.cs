using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites.User
{
    public class SingUp_u
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        // Navigation property for Login
        public virtual Login Login { get; set; }
    }
}
