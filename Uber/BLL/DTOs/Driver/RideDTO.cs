using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Driver
{
    public class RideDTO
    {
        public int RideID { get; set; }

        public int UserID { get; set; }

        public int DriverID { get; set; }

        public string PickupLocation { get; set; }

        public string Destination { get; set; }

        public decimal Fare { get; set; }

        public string Status { get; set; }
    }
}