using DAL.EF.Entites;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Entities.Admin
{
    public class PasswordChange
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Login")]
        public int LoginId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public DateTime ChangeRequestedAt { get; set; }
      
        public int Code { get; set; }

        // Navigation property
        public virtual Login Login { get; set; }
    }
}
