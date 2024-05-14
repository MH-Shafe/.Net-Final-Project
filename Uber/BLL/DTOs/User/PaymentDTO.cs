using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs.User
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserID { get; set; }
        // Other payment details as needed
    }
}
