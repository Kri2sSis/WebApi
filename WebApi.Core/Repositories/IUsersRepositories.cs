using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Repositories
{
    public interface IUsersRepositories
    {

        Task<bool> Add(User[] user);

        Task<User[]> Get(FilterRequest? filterRequest);

        Task<User> Get(string idUser);

    }
}
