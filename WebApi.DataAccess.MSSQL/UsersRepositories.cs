
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Repositories;

namespace WebApi.DataAccess.MSSQL
{
    public class UsersRepositories : IUsersRepositories
    {
        private readonly WebApiDbContext _context;

        public UsersRepositories(WebApiDbContext context)
        {
            _context = context;
        }


        public async Task<string> Add(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var newUser = new Entities.User
            {
                UserId = user.UserId,
                UserFullName = user.UserFullName,
                Sex = user.Sex,
                Age = user.Age
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser.UserId;
        }

        public async Task<User[]> Get()
        {
            List<User> userCore = new List<User>();
            var users = await _context.Users.AsNoTracking().ToArrayAsync();
            if(users.Count() <= 1)
            {
                return null;
            }
            foreach (var user in users)
            {
                userCore.Add(new User
                {
                    UserId = user.UserId,
                    UserFullName=user.UserFullName,
                    Sex=user.Sex,
                    Age=user.Age
                });
            }
            return userCore.ToArray();
        }

        public async Task<User> Get(string idUser)
        {
            if (idUser is null)
            {
                throw new ArgumentNullException(nameof(idUser));
            }

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == idUser);
            if (user is null)
            {
                throw new InvalidOperationException("User not existed");
            }
            return new User {
                    UserId = user.UserId,
                    UserFullName = user.UserFullName,
                    Sex = user.Sex,
                    Age = user.Age
            };

        }
    }
}
