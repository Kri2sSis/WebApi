using AutoMapper;
using WebApi.Contracts;

namespace WebApi
{
    public class ContractMapperProfile : Profile
    {
        public ContractMapperProfile()
        {
            CreateMap<Core.Repositories.User, User>();
        }
    }
}
