using WebApi.Core.Repositories;

namespace WebApi.Core.Tele2Api
{
    public interface ITele2ApiUsers
    {

        public Task<User[]> Get();

    }
}
