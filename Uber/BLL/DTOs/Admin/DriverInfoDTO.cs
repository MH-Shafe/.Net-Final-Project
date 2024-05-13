using BLL.DTOs.Admin; // Import SignUpDTO if it's not already imported
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Admin
{
    public class DriverInfoDTO
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public string VehicleModel { get; set; }
        public string VehiclePlateNumber { get; set; }

        public int SignUpId { get; set; }

        public SignUpDTO SignUp { get; set; } 
    }
}
