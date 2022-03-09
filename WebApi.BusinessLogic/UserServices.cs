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




        public async Task<User[]> Get(FilterRequest filterRequest)
        {
            var users = await _userRepository.Get(filterRequest);
            if(users == null)
            {
                await CreatUserTele2();
                return await _userRepository.Get(filterRequest);
            }

            return users;
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
                await CreatUserTele2();
            }
            user = await _userRepository.Get(userId);

            return user;
        }

        private async Task<bool> CreatUserTele2()
        {
            
            var usersTele2 = await _tele2ITele2Api.Get();
            await _userRepository.Add(usersTele2);

            return true;
        }
       
    }
}