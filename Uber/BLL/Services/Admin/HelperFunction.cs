using System.Linq;
using DAL.EF.Entities;
using DAL.EF.Entities.Admin;
using BLL.DTOs;
using BLL.DTOs.Admin;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites;
using System.Collections.Generic;
using DAL;

public static class HelperFunction
{
    public static DriverInfo MapToDriverInfo(DriverInfoDTO dto)
    {
        if (dto == null)
            return null;

        return new DriverInfo
        {
            Id = dto.Id,
            LicenseNumber = dto.LicenseNumber,
            LicenseExpiration = dto.LicenseExpiration,
            VehicleModel = dto.VehicleModel,
            VehiclePlateNumber = dto.VehiclePlateNumber,
            SignUpId = dto.SignUpId
        };
    }

    public static SignUp MapToSignUp(SignUpDTO dto)
    {
        if (dto == null)
            return null;

        var signUp = new SignUp
        {
            username = dto.username,
            Name = dto.Name,
            Email = dto.Email,
            Country = dto.Country
        };

        return signUp;
    }

    public static List<Login> MapToLogins(List<LoginDTO> loginDTOs)
    {
        if (loginDTOs == null || !loginDTOs.Any())
            return null;

        return loginDTOs.Select(dto => new Login
        {
            username = dto.username,
            password = dto.password,
            roll = dto.roll
        }).ToList();
    }

    public static Login MapToLogin(LoginDTO dto)
    {
        if (dto == null)
            return null;

        return new Login
        {
            username = dto.username,
            password = dto.password,
            roll = dto.roll,
            SignUpId = dto.SignUpId
        };
    }
    public static void DeleteLogins(string username)
    {
        var loginRepo = DataFactory.LoginData();
        var loginsToDelete = loginRepo.Get().Where(l => l.username == username).ToList();
        foreach (var login in loginsToDelete)
        {
            loginRepo.Delete(login.Id);
        }
    }

}
