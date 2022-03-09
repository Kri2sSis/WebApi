using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
