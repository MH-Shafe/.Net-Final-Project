using DAL.EF.Entites.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string sender, string recipient, string subject, string body);
        List<Email> GetAllEmails();
        void DeleteEmail(int id);
    }
}
