using ClinicManagement.Application.DTOs;
using ClinicManagement.Domain.Entities;
using Mapster;

namespace ClinicManagement.Application
{
    public class MappingRegister : IRegister
    {
        //public void RegisterMapsterConfiguration(this IServiceCollection services)
        //{
        //    TypeAdapterConfig<EmployeeDTO, Employee>
        //    .NewConfig()
        //    .Map(dest => dest.BirthDate, src => src.BirthDate)
        //    .Map(dest => dest.Gender, src => src.Gender)
        //    .Map(dest => dest.User.UserName, src => src.UserName)
        //    .Map(dest => dest.User.Name, src => src.Name)
        //    .Map(dest => dest.User.Email, src => src.Email)
        //    .Map(dest => dest.User.Id, src => src.Id)
        //    .Map(dest => dest.User.Password, src => src.Password)
        //    .Map(dest => dest.User.Phone, src => src.Phone)
        //    .Map(dest => dest.User.Photo, src => src.Photo)
        //    .Map(dest => dest.User.ModifiedDate, src => src.ModifiedDate)
        //    .Map(dest => dest.User.CreatedDate, src => src.CreatedDate)
        //    .Map(dest => dest.User.UserRoles, src => new List<UserRole>()
        //            {
        //                new UserRole()
        //                {
        //                   Id = 0 ,
        //                   RoleId = 2 ,
        //                   UserId = src.Id
        //                }
        //            });


        //    var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        //    Assembly applicationAssembly = typeof(BaseModelDTO<,>).Assembly;
        //    typeAdapterConfig.Scan(applicationAssembly);

        //}
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EmployeeDTO, Employee>()
                        .Map(dest => dest.BirthDate, src => src.BirthDate)
                        .Map(dest => dest.Gender, src => src.Gender)
                        .Map(dest => dest.User.UserName, src => src.UserName)
                        .Map(dest => dest.User.Name, src => src.Name)
                        .Map(dest => dest.User.Email, src => src.Email)
                        .Map(dest => dest.User.Id, src => src.Id)
                        .Map(dest => dest.User.Password, src => src.Password)
                        .Map(dest => dest.User.Phone, src => src.Phone)
                        .Map(dest => dest.User.Photo, src => src.Photo)
                        .Map(dest => dest.User.ModifiedDate, src => src.ModifiedDate)
                        .Map(dest => dest.User.CreatedDate, src => src.CreatedDate)
                        //.Map(dest => dest.User.UserRoles, src => new List<UserRole>())
                        .AfterMapping((src, dest) =>
                        {
                            dest.User.UserRoles.Add(new UserRole()
                            {
                                Id = 0,
                                RoleId = 2,
                                UserId = src.Id,
                                CreatedDate = DateTime.Now,
                                ModifiedDate  = DateTime.Now
                            });
                        });
            ///////////////////////////
            config.NewConfig<Employee, EmployeeDTO>()
                .Map(dest => dest.Name, src => src.User.Name)
                .Map(dest => dest.UserName, src => src.User.UserName)
                .Map(dest => dest.BirthDate, src => src.BirthDate)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.Gender, src => src.Gender)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Phone, src => src.User.Phone)
                .Map(dest => dest.Photo, src => src.User.Photo)
                .Map(dest => dest.Password, src => src.User.Password)
                .Map(dest => dest.ModifiedDate, src => src.User.ModifiedDate)
                .Map(dest => dest.CreatedDate, src => src.User.CreatedDate);
        }
    }
}