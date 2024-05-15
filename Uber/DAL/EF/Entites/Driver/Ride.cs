using DAL.EF.Entities.Driver;
using DAL.EF.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites.User
{

    public class Ride
    {
        [Key]
        public int RideID { get; set; } // Primary Key

        [ForeignKey("User")]
        public int UserID { get; set; } // Foreign Key to User.UserID

        [ForeignKey("Driver")]
        public int DriverID { get; set; } // Foreign Key to Driver.DriverID

        public string PickupLocation { get; set; }

        public string Destination { get; set; }

        public decimal Fare { get; set; }

        public string Status { get; set; } // e.g., requested, accepted, completed, canceled

        // Navigation properties
        public virtual UserEF User { get; set; }
        public virtual DriverEF Driver { get; set; }
    }
}