using AutoMapper;
using WebApi.DataAccess.MSSQL.Entities;

namespace WebApi.DataAccess.MSSQL
{
    public class DataAccesseMappingProfile : Profile
    {

        public DataAccesseMappingProfile()
        {
            CreateMap<User, Core.Repositories.User>().ReverseMap();
        }


    }
}
