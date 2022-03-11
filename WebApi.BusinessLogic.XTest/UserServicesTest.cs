using AutoFixture;
using Moq;
using WebApi.Core.Repositories;
using WebApi.Core.Tele2Api;

namespace WebApi.BusinessLogic.XTest
{
    public class UserServicesTest
    {
        private readonly Fixture _fixture;
        private readonly Mock<IUsersRepositories> _usersRepositoriesMock;
        private readonly Mock<ITele2ApiUsers> _tele2ApiUsersMock;
        private readonly UserServices _userServices;

        public UserServicesTest()
        {
            _fixture = new Fixture();
            _usersRepositoriesMock = new Mock<IUsersRepositories>();
            _tele2ApiUsersMock = new Mock<ITele2ApiUsers>();
            _userServices = new UserServices(_usersRepositoriesMock.Object, _tele2ApiUsersMock.Object);
        }




    }
}