using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs.User
{
    public class PaymentDTO
    {
        [Key]
        public int PaymentID { get; set; } // Primary Key

        public string PaymentMethod { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; } // Foreign key property

        // It's recommended not to have navigation properties in DTOs
        // If needed, you might want to include just the foreign key
        // public virtual User User { get; set; } // Navigation property
    }
}
