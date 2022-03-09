﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public interface IUsersServices
    {

        Task<Repositories.User[]> Get(FilterRequest? filterRequest);

        Task<Repositories.User> Get(string userId);

    }
}
