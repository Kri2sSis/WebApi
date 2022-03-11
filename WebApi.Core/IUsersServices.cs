namespace WebApi.Core
{
    public interface IUsersServices
    {

        Task<Repositories.User[]> Get(FilterRequest? filterRequest);

        Task<Repositories.User> Get(string userId);

    }
}
