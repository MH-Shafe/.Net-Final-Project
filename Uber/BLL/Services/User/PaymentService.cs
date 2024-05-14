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
    public class PaymentService
    {
        public static PaymentDTO Get(int id)
        {
            var data = DataFactory.Payment_uData().Get(id);
            return MapToDTO(data);
        }

        public static void Create(PaymentDTO dto)
        {
            var payment = MapToEntity(dto);
            DataFactory.Payment_uData().Create(payment);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataFactory.Payment_uData().Get();
            return data.Select(MapToDTO).ToList();
        }

        private static PaymentDTO MapToDTO(Payment_u entity)
        {
            return new PaymentDTO
            {
                PaymentID = entity.PaymentID,
                PaymentMethod = entity.PaymentMethod,
                TransactionAmount = entity.TransactionAmount,
                Timestamp = entity.Timestamp,
                UserID = entity.UserID
                // You might want to include navigation properties if needed
            };
        }

        private static Payment_u MapToEntity(PaymentDTO dto)
        {
            return new Payment_u
            {
                PaymentID = dto.PaymentID,
                PaymentMethod = dto.PaymentMethod,
                TransactionAmount = dto.TransactionAmount,
                Timestamp = dto.Timestamp,
                UserID = dto.UserID
            };
        }
    }
}
