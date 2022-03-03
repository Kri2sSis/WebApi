using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public interface IUsersServices
    {
        Task<string> Create(Repositories.User user);

        Task<Repositories.User[]> Get(PaginationConfiguration pagination, FilterConfiguration filter);

        Task<Repositories.User> Get(string userId);

    }
}
