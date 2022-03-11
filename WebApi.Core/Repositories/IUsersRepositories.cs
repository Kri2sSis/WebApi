namespace WebApi.Core.Repositories
{
    public interface IUsersRepositories
    {

        Task<bool> Add(User[] user);

        Task<User[]> Get(FilterRequest? filterRequest);

        Task<User> Get(string idUser);

    }
}
