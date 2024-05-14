using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOs.User;
using DAL;
using DAL.EF.Entites.User;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SubscriptionService
    {
        public static SubscriptionDTO Get(int id)
        {
            var data = DataFactory.Subscription_uData().Get(id);
            return MapToDTO(data);
        }

        public static void Create(SubscriptionDTO dto)
        {
            var subscription = MapToEntity(dto);
            DataFactory.Subscription_uData().Create(subscription);
        }

        public static List<SubscriptionDTO> Get()
        {
            var data = DataFactory.Subscription_uData().Get();
            return data.Select(MapToDTO).ToList();
        }

        public static void Update(SubscriptionDTO dto)
        {
            var subscription = MapToEntity(dto);
            DataFactory.Subscription_uData().Update(subscription);
        }

        public static void Delete(int id)
        {
            DataFactory.Subscription_uData().Delete(id);
        }

        private static SubscriptionDTO MapToDTO(Subscription_u entity)
        {
            return new SubscriptionDTO
            {
                SubscriptionID = entity.SubscriptionID,
                Type = entity.Type,
                Duration = entity.Duration,
                Price = entity.Price,
                ExpiryDate = entity.ExpiryDate,
                UserID = entity.UserID
                // Add additional mapping if needed
            };
        }

        private static Subscription_u MapToEntity(SubscriptionDTO dto)
        {
            return new Subscription_u
            {
                SubscriptionID = dto.SubscriptionID,
                Type = dto.Type,
                Duration = dto.Duration,
                Price = dto.Price,
                ExpiryDate = dto.ExpiryDate,
                UserID = dto.UserID
                // Add additional mapping if needed
            };
        }
    }
}
