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

    }
}
