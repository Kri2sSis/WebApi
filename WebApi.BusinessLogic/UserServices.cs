using System;
using WebApi.Core;
using WebApi.Core.Repositories;
using WebApi.Core.Tele2Api;

namespace WebApi.BusinessLogic
{
    public class UserServices : IUsersServices
    {

        private readonly IUsersRepositories _userRepository;
        private readonly ITele2ApiUsers _tele2ITele2Api;

        public UserServices(IUsersRepositories usersRepositories, ITele2ApiUsers tele2ITele2Api)
        {
            _userRepository = usersRepositories;
            _tele2ITele2Api = tele2ITele2Api;
        }


        public async Task<string> Create(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = await _userRepository.Get(user.UserId);
            if (existingUser is not null)
            {
                throw new InvalidOperationException("User alredy existing");
            }

            var createdUser = await _userRepository.Add(user);

            return createdUser;

        }

        public async Task<User[]> Get(PaginationConfiguration pagination, FilterConfiguration filter)
        {
            var users = await _userRepository.Get();
            if(users == null)
            {
                CreatUserTele2();
            }

            return await Filter(pagination, filter);
        }

        public async Task<User> Get(string userId)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            var user = await _userRepository.Get(userId);
            if (user == null)
            {
                CreatUserTele2();
            }
            user = await _userRepository.Get(userId);

            return user;
        }

        private void CreatUserTele2()
        {
            
            var usersTele2 = _tele2ITele2Api.Get();
            foreach (var user in usersTele2)
            {
                _userRepository.Add(new User
                {
                    UserId = user.UserId,
                    UserFullName = user.UserFullName,
                    Sex = user.Sex,
                    Age = user.Age
                });
            }
        }

        private async Task<User[]> Filter(PaginationConfiguration pagination, FilterConfiguration filter)
        {
             User[] user = await _userRepository.Get();
            if(!String.IsNullOrWhiteSpace(filter.sex))
            {
                if(filter.ageMin != default(int))
                {
                    user = user.Where(user => user.Age > filter.ageMin & user.Age < filter.ageMax & user.Sex == filter.sex).ToArray();
                    return Pagination(pagination, user);
                }
                user = user.Where(x => x.Sex == filter.sex).ToArray();
                return Pagination(pagination, user);
            }
            else if(filter.ageMin != default(int))
            {
                user = user.Where(user => user.Age > filter.ageMin & user.Age < filter.ageMax).ToArray();
                return Pagination(pagination, user);
            }
            return Pagination(pagination, user);
        }

        private User[] Pagination(PaginationConfiguration pagination, User[] users)
        {
            return users
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToArray();
        }

       
    }
}