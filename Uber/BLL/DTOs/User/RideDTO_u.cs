using BLL.DTOs.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.User
{
    
    public class RideDTO
    {
        [Key]
        public int RideID { get; set; } // Primary Key

        public int UserID { get; set; } // Foreign Key to User.UserID

        public int DriverID { get; set; } // Foreign Key to Driver.DriverID

        public string PickupLocation { get; set; }

        public string Destination { get; set; }

        public decimal Fare { get; set; }

        public string Status { get; set; } // e.g., requested, accepted, completed, canceled

        // Navigation properties
        public virtual UserDTO User { get; set; }

        public virtual DriverDTO Driver { get; set; }
    }
}

