using AutoMapper;
using BLL.DTOs.Admin;
using DAL;
using DAL.EF.Entites.Admin;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BLL.Services.Admin
{
    public class EmailService
    {
        public static EmailDTO Get(int id)
        {
            var data = DataFactory.EmailData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Email, EmailDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<EmailDTO>(data);
            return ret;
        }

        public static void Create(EmailDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmailDTO, Email>();
            });
            var mapper = new Mapper(config);
            var entity = mapper.Map<Email>(dto);
            entity.Timestamp = DateTime.Now; // Set current timestamp
            DataFactory.EmailData().Create(entity);
        }

        public static List<EmailDTO> GetAll()
        {
            var data = DataFactory.EmailData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Email, EmailDTO>();
            });
            var mapper = new Mapper(config);
            var dtos = mapper.Map<List<EmailDTO>>(data);

            return dtos;
        }

        public static void Delete(int id)
        {
            DataFactory.EmailData().Delete(id);
        }
    }
}
