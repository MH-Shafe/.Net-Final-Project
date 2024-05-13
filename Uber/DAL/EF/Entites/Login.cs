using DAL.EF.Entites.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites
{
    public class Login
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roll { get; set; }

        // Foreign key and part of the key
        [ForeignKey("SignUp")]
        public int SignUpId { get; set; }

        // Navigation property
        public virtual SignUp SignUp { get; set; }

    }
}
