using AutoMapper;
using FluentAssertions;
using Moq;
using UserManagement.Application.Features.Users.Queries.Handlers;
using UserManagement.Application.Features.Users.Queries.Models;
using UserManagement.Application.Features.Users.Queries.Results;
using UserManagement.Application.Mapping.Users;
using UserManagement.Application.IServices;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enum;
using Microsoft.Extensions.Localization;
using UserManagement.Application.Resources;

namespace UserManagement.XUnitTest.ApplicationTest.UsersTest.Queries
{
    public class GetUsersListTest
    {
        private readonly Mock<IAppUserService> _userServiceMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;
        private readonly UserProfile _userProfile;

        public GetUsersListTest()
        {
            _userServiceMock = new();
            _userProfile = new();
            _localizerMock = new();
            var configratin = new MapperConfiguration(c => c.AddProfile(_userProfile));
            _mapperMock = new Mapper(configratin);
        }

        [Fact]
        public async Task Handle_UsersList_Should_NotNull_And_NotEmpty()
        {
            Thread.Sleep(3000);

            //Arrange
            var userList = new List<AppUser>()
            {
                new AppUser() {Id=1, FirstName="Ameen", LastName="Hameed", Email="ameen@gmail.com", UserName="ameen@gmail.com", Password="Ameen@000", Status=UserStatus.Active, DepartmentId = 1},
                new AppUser() {Id=2, FirstName="Salah", LastName="Mohammed", Email="salah@gmail.com", UserName="salah@gmail.com", Password="Salah@000", Status=UserStatus.Active, DepartmentId = 1},
                new AppUser() {Id=3, FirstName="Ahmed", LastName="Ali", Email="ahmed@gmail.com", UserName="ahmed@gmail.com", Password="Ahmed@000", Status=UserStatus.Active, DepartmentId = 1}
            };

            var query = new GetUsersListQuery();
            _userServiceMock.Setup(d => d.GetUsersLists()).Returns(Task.FromResult(userList));
            var handle = new UserQueryHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            //Act
            var result = await handle.Handle(query, default);
            
            //Assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Data.Should().BeOfType<List<GetUsersListResponse>>();
            result.Succeeded.Should().BeTrue();
        }
    }
}
