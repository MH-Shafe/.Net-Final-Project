using AutoMapper;
using BLL.DTOs.Admin;
using DAL;
using DAL.EF.Entities.Admin;
using DAL.Repos.Admin;
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
    }
}
