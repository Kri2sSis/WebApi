using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Repositories
{
    public interface IUsersRepositories
    {

        Task<string> Add(User user);

        Task<User[]> Get();

        Task<User> Get(string idUser);

    }
}
