using AutoMapper;
using BLL.DTOs.Admin;
using DAL;
using DAL.EF.Entities.Admin;
using DAL.Repos.Admin;
using System;
using System.Collections.Generic;

namespace BLL.Services.Admin
{
    public class DriverInfoService
    {
        public static DriverInfoDTO Get(int id)
        {
            var data = DataFactory.DriverInfoData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DriverInfo, DriverInfoDTO>()
                   .ForMember(dest => dest.SignUp, opt => opt.MapFrom(src => new SignUpDTO
                   {
                       Id = src.SignUp.Id,
                       username = src.SignUp.username,
                       Name = src.SignUp.Name,
                       Email = src.SignUp.Email,
                       Country = src.SignUp.Country
                   }));
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<DriverInfoDTO>(data);
            return ret;
        }
        /*
        public static void Create(DriverInfoDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DriverInfoDTO, DriverInfo>();
            });
            var mapper = new Mapper(config);
            var entity = mapper.Map<DriverInfo>(dto);
            DataFactory.DriverInfoData().Create(entity);
        }
        */

        public static void Create(DriverInfoDTO dto)
        {
            // Map DriverInfoDTO to DriverInfo entity
            var driverInfoEntity = HelperFunction.MapToDriverInfo(dto);

            // Map SignUpDTO to SignUp entity
            var signUpEntity = HelperFunction.MapToSignUp(dto.SignUp);

            // Map LoginDTOs to Login entities
            var loginEntities = HelperFunction.MapToLogins(dto.SignUp.Logins);

            // Create SignUp entity
            DataFactory.SignUpData().Create(signUpEntity);

            // Associate DriverInfo with SignUp
            driverInfoEntity.SignUpId = signUpEntity.Id;

            // Create DriverInfo entity
            DataFactory.DriverInfoData().Create(driverInfoEntity);

            // Create Login entities
            if (loginEntities != null)
            {
                foreach (var login in loginEntities)
                {
                    // Assign SignUpId to each login
                    login.SignUpId = signUpEntity.Id;
                    DataFactory.LoginData().Create(login);
                }
            }
        }

        public static List<DriverInfoDTO> GetAll()
        {
            var data = DataFactory.DriverInfoData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DriverInfo, DriverInfoDTO>()
                   .ForMember(dest => dest.SignUp, opt => opt.MapFrom(src => new SignUpDTO
                   {
                       Id = src.SignUp.Id,
                       username = src.SignUp.username,
                       Name = src.SignUp.Name,
                       Email = src.SignUp.Email,
                       Country = src.SignUp.Country
                   }));
            });
            var mapper = new Mapper(config);
            var dtos = mapper.Map<List<DriverInfoDTO>>(data);

            return dtos;
        }
        
        public static void Delete(int id)
        {            
            var driverInfo = DataFactory.DriverInfoData().Get(id);            
            if (driverInfo == null)
            {                
                return;
            }            
            DataFactory.DriverInfoData().Delete(driverInfo.Id);
        }
        
        /*
        public static void Delete(int id)
        {
            // Get the DriverInfo entity by its ID
            var driverInfo = DataFactory.DriverInfoData().Get(id);

            // If the entity doesn't exist, return or throw an exception as needed
            if (driverInfo == null)
            {
                // You may choose to throw an exception or return here based on your application's requirements
                return;
            }

            // Delete the associated sign-up
            SignUpService.Delete(driverInfo.SignUpId);

            // Delete the entity
            DataFactory.DriverInfoData().Delete(driverInfo.Id);
        }
        */
    }
}
