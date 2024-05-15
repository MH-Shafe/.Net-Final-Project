using BLL.DTOs.Admin;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entities.Admin;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace BLL.Services.Admin
{
    public class PasswordChangeService
    {
        private readonly IRepo<PasswordChange, int> _passwordChangeRepo;
        private readonly IRepo<SignUp, int> _signUpRepo;
        private readonly IRepo<Login, int> _loginRepo;

        public PasswordChangeService(IRepo<PasswordChange, int> passwordChangeRepo, IRepo<SignUp, int> signUpRepo, IRepo<Login, int> loginRepo)
        {
            _passwordChangeRepo = passwordChangeRepo;
            _signUpRepo = signUpRepo;
            _loginRepo = loginRepo;
        }

        public void Create(PasswordChangeDTO dto)
        {
            // Retrieve login from database using dto.LoginId
            var login = _loginRepo.Get(dto.LoginId);

            // Check if login exists and old password matches
            if (login == null || login.password != dto.OldPassword)
            {
                throw new Exception("Invalid LoginId or OldPassword.");
            }

            // Update password if OldPassword matches
            login.password = dto.NewPassword;

            // Save the updated login
            _loginRepo.Update(login);

            // Create the password change record
            var passwordChange = MapToEntity(dto);
            _passwordChangeRepo.Create(passwordChange);

            // Get the recipient's email from the SignUp table
            var signUp = _signUpRepo.Get(login.SignUpId);
            if (signUp == null)
            {
                throw new Exception("User not found in SignUp table.");
            }

            // Send email notification
            SendPasswordChangeEmail(signUp.Email, dto.OldPassword);
        }

        private void SendPasswordChangeEmail(string recipientEmail, string oldPassword)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("mhshafe83@gmail.com");
                message.To.Add(new MailAddress(recipientEmail)); // Using the recipient email from SignUp
                message.Subject = "Password Change Notification";
                message.Body = $"Your password has been changed successfully. Your old password was: {oldPassword}";

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("mhshafe83@gmail.com", "lcxz ndpa wrka ejkk");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
                Console.WriteLine($"Error sending password change email: {ex.Message}");
            }
        }

        public PasswordChangeDTO Get(int id)
        {
            var passwordChange = _passwordChangeRepo.Get(id);
            if (passwordChange == null)
            {
                throw new Exception("Password change not found.");
            }

            return MapToDTO(passwordChange);
        }

        public List<PasswordChangeDTO> GetAll()
        {
            var passwordChanges = _passwordChangeRepo.Get();
            return passwordChanges.Select(MapToDTO).ToList();
        }

        private PasswordChangeDTO MapToDTO(PasswordChange entity)
        {
            return new PasswordChangeDTO
            {
                Id = entity.Id,
                LoginId = entity.LoginId,
                OldPassword = entity.OldPassword,
                NewPassword = entity.NewPassword,
                ChangeRequestedAt = entity.ChangeRequestedAt,
                Code = entity.Code
            };
        }

        private PasswordChange MapToEntity(PasswordChangeDTO dto)
        {
            return new PasswordChange
            {
                Id = dto.Id,
                LoginId = dto.LoginId,
                OldPassword = dto.OldPassword,
                NewPassword = dto.NewPassword,
                ChangeRequestedAt = dto.ChangeRequestedAt,
                Code = dto.Code
            };
        }
    }
}
