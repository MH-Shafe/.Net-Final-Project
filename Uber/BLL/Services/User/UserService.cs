using BLL.DTOs.User;
using DAL;
using DAL.EF.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.User
{
  
    public class UserService
    {
        public static UserDTO Get(int id)
        {
            var data = DataFactory.UserEFData().Get(id);
            return MapToDTO(data);
        }

        public static void Create(UserDTO dto)
        {
            var user = MapToEntity(dto);
            DataFactory.UserEFData().Create(user);
        }

        public static List<UserDTO> Get()
        {
            var data = DataFactory.UserEFData().Get();
            return data.Select(MapToDTO).ToList();
        }

        private static UserDTO MapToDTO(UserEF entity)
        {
            return new UserDTO
            {
                UserID = entity.UserID,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                PhoneNumber = entity.PhoneNumber,
                Payments = entity.Payments?.Select(p => new PaymentDTO
                {
                    PaymentID = p.PaymentID,
                    PaymentMethod = p.PaymentMethod,
                    TransactionAmount = p.TransactionAmount,
                    Timestamp = p.Timestamp,
                    UserID = p.UserID
                }).ToList()
            };
        }

        private static UserEF MapToEntity(UserDTO dto)
        {
            return new UserEF
            {
                UserID = dto.UserID,
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber
                // You might want to include navigation properties if needed
            };
        }
    }
}