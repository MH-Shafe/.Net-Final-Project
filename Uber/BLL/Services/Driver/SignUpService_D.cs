using AutoMapper;
using BLL.DTOs.Admin;
using BLL.DTOs.Driver;
using DAL.EF.Entites;
using DAL;
using System.Collections.Generic;
using DAL.EF.Entites.Driver;

public class SignUpService_D
{
    private static IMapper mapper;

    static SignUpService_D() // Add a static constructor to initialize mapper
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SignUp_D, SignUpDTO_D>();
            cfg.CreateMap<SignUpDTO_D, SignUp_D>();
        });
        mapper = config.CreateMapper();
    }

    public static SignUpDTO_D Get(int id)
    {
        var data = DataFactory.SignUpData_D().Get(id); // Use SignUpData_D() instead of SignUpData()
        var ret = mapper.Map<SignUpDTO_D>(data);
        return ret;
    }

    public static void CreateSignUp(SignUpDTO_D dto)
    {
        var signUp = mapper.Map<SignUp_D>(dto);
        DataFactory.SignUpData_D().Create(signUp); // Use SignUpData_D() instead of SignUpData()
    }

    public static List<SignUpDTO_D> GetSignUps()
    {
        var data = DataFactory.SignUpData_D().Get(); // Use SignUpData_D() instead of SignUpData()
        var retData = mapper.Map<List<SignUpDTO_D>>(data);
        return retData;
    }

    public static void CreateSignUpAndLogin(SignUpLoginDTO dto) // Changed method name
    {
        var signUp_D = mapper.Map<SignUp_D>(dto.SignUp_D);
        DataFactory.SignUpData_D().Create(signUp_D); // Use SignUpData_D() instead of SignUpData()

        dto.Login.SignUpId = signUp_D.Id;

        var login = mapper.Map<Login>(dto.Login);
        DataFactory.LoginData().Create(login);
    }
}
