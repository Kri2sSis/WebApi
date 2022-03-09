
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Core.Repositories;

namespace WebApi.DataAccess.MSSQL
{
    public class UsersRepositories : IUsersRepositories
    {
        private readonly WebApiDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepositories(WebApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> Add(User[] users)
        {
            if (users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var newUser = _mapper.Map<User[], Entities.User[]>(users);

            await _context.Users.AddRangeAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User[]> Get(FilterRequest? filterRequest)
        {
            var pagination = filterRequest.PaginationConfiguration;
            var filter = filterRequest.FilterConfiguration;
            var query = _context.Users.AsNoTracking().AsQueryable();
            if (!query.Any() || query == null)
            {
                return null;
            }
            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Sex))
                {
                    query = query.Where(x => x.Sex == filter.Sex);
                }
                if(filter.AgeMin != default(int))
                {
                    query = query.Where(x => x.Age > filter.AgeMin & x.Age < filter.AgeMax);
                }
            }
            var users = await query.Skip((pagination.PageNumber-1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToArrayAsync();

            return _mapper.Map<Entities.User[], User[]>(users);
        }

        public async Task<User> Get(string UserId)
        {
            if (String.IsNullOrWhiteSpace(UserId))
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == UserId);
            if (user is null)
            {
                throw new InvalidOperationException("User not existed");
            }
            return _mapper.Map<Entities.User, User>(user);

        }
    }
}
