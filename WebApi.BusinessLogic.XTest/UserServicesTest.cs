using AutoFixture;
using Moq;
using WebApi.Core.Repositories;
using WebApi.Core.Tele2Api;
using Xunit;

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

        [Fact]
        public async void Create_ValidUser_ShouldReturnUserId()
        {
            //arange
            var expectedUserId = _fixture.Create<string>();

            var user = _fixture.Build<User>()
                                .Without(x => x.UserId)
                                .Create();

            _usersRepositoriesMock.Setup(x => x.Add(user)).ReturnsAsync(expectedUserId);

            //act
            var userId = await _userServices.Create(user);

            //assert
            Assert.Equal(expectedUserId, userId);
            _usersRepositoriesMock.Verify(x=> x.Add(user), Times.Once);
            _usersRepositoriesMock.Verify(x => x.Get(), Times.Once);
            _tele2ApiUsersMock.Verify(x => x.Get(), Times.Once);
        }

        [Fact]
        public async void Create_UserIsNull_ShouldThrowArgumentNullException()
        {
            //arange
            //act
            await Assert.ThrowsAsync<ArgumentNullException>(()=> _userServices.Create(null));
            // assert
            _usersRepositoriesMock.Verify(x=> x.Add(It.IsAny<User>()), Times.Never);
        }

    }
}