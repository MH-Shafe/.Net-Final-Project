using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.EF.Entites.Driver;


namespace DAL.EF.Entities.Driver

{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; } // Primary Key

        public string PaymentMethod { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("Driver")]
        public int DriverID { get; set; }

        // Navigation property for the driver
        public virtual DriverEF Driver { get; set; }

    }
}