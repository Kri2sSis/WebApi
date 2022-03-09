using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Repositories;

namespace WebApi.Core.Tele2Api
{
    public interface ITele2ApiUsers
    {

        public Task<User[]> Get();

    }
}
