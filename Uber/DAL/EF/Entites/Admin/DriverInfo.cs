using DAL.EF.Entites.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entities.Admin
{
    public class DriverInfo
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public string VehicleModel { get; set; }
        public string VehiclePlateNumber { get; set; }

        // Foreign key for SignUp
        public int SignUpId { get; set; }

        // Navigation property for SignUp
        public virtual SignUp SignUp { get; set; }
    }
}
