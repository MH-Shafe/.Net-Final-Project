using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs.Admin
{
    public class PasswordChangeDTO
    {       
        public int Id { get; set; }    
        public int LoginId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public DateTime ChangeRequestedAt { get; set; }
        public int Code { get; set; }
        // Navigation property
        public virtual LoginDTO Login { get; set; } // Changed from Login to LoginDTO
    }
}
