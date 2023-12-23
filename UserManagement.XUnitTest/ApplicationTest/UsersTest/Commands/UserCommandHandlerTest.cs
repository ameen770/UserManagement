using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using UserManagement.Application.Features.Users.Commands.Handlers;
using UserManagement.Application.Features.Users.Commands.Models;
using UserManagement.Application.Mapping.Users;
using UserManagement.Application.Resources;
using UserManagement.Domain.Entities;
using UserManagement.Application.IServices;
using System.Net;
using UserManagement.Application.Services;
using UserManagement.Domain.Enum;

namespace UserManagement.XUnitTest.ApplicationTest.UsersTest.Commands
{
    public class UserCommandHandlerTest
    {
        private readonly Mock<IAppUserService> _userServiceMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;
        private readonly UserProfile _userProfile;


        public UserCommandHandlerTest()
        {
            _userProfile = new();
            _userServiceMock = new();
            _localizerMock = new();
            var configuration = new MapperConfiguration(c => c.AddProfile(_userProfile));
            _mapperMock=new Mapper(configuration);
        }

        // ==========================================================================


        [Fact]
        public async Task Handle_AddUser_Should_Add_Data_And_StatusCode201()
        {
            Thread.Sleep(3000);

            //Arrange
            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);
            var addUserCommand = new AddUserCommand() { FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = "1", DepartmentId = 1 };
            _userServiceMock.Setup(x => x.AddAsync(It.IsAny<AppUser>())).Returns(Task.FromResult("Success"));
            //act
            var result = await handler.Handle(addUserCommand, default);
            //Assert
            result.Succeeded.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            _userServiceMock.Verify(x => x.AddAsync(It.IsAny<AppUser>()), Times.Once, "Not Called");
        }

        [Fact]
        public async Task Handle_AddUser_Should_return_StatusCode400()
        {
            Thread.Sleep(3000);

            //Arrange
            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);
            var addUserCommand = new AddUserCommand() { FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = "1", DepartmentId = 1 };
            _userServiceMock.Setup(x => x.AddAsync(It.IsAny<AppUser>())).Returns(Task.FromResult(""));
            //Act
            var result = await handler.Handle(addUserCommand, default);
            //Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _userServiceMock.Verify(x => x.AddAsync(It.IsAny<AppUser>()), Times.Once, "Not Called");
        }

        // ==========================================================================

        /*[Fact]
        public async Task Handle_EditUser_Should_Return_NotFoundResponse_404()
        {
            //Arrange
            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);
            var updateUserCommand = new EditUserCommand() { Id = 6, FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = "1", DepartmentId = 1 };
            AppUser user = null;
            int xResult = 0;
            _userServiceMock.Setup(x => x.GetUserByIds(updateUserCommand.Id)).Returns(Task.FromResult(user)).Callback((int x) => xResult = x);
            //Act
            var result = await handler.Handle(updateUserCommand, default);
            //Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            xResult.Should().Be(6);
            Assert.Equal(xResult, updateUserCommand.Id);
            _userServiceMock.Verify(x => x.GetUserByIds(It.IsAny<int>()), Times.Once, "Not Called");
        }*/

        [Fact]
        public async Task Handle_EditUser_Should_Return_NotFoundResponse_404()
        {
            Thread.Sleep(3000);

            // Arrange
            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);
            var updateUserCommand = new EditUserCommand() { Id = 6, FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = "1", DepartmentId = 1 };
            AppUser user = null;

            _userServiceMock.Setup(x => x.GetUserByIds(updateUserCommand.Id)).ReturnsAsync(user);

            // Act
            var result = await handler.Handle(updateUserCommand, default);

            // Assert      
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            _userServiceMock.Verify(x => x.GetUserByIds(updateUserCommand.Id), Times.Once, "Not Called");
            //_userServiceMock.Verify(x => x.GetUserByIds(It.IsAny<int>()), Times.Once, "Not Called");
            _userServiceMock.Verify(x => x.EditAsync(It.IsAny<AppUser>()), Times.Never);
        }


        [Fact]
        public async Task Handle_EditUser_Should_Return_SuccessResponse_200()
        {
            Thread.Sleep(3000);

            // Arrange
            var userId = 1;
            var request = new EditUserCommand
            {
                Id = userId,
                FirstName = "Salah",
                LastName = "Mohammed",
                Email = "salah@gmail.com",
                UserName = "salah@gmail.com",
                Password = "Salah@000",
                Status = "1",
                DepartmentId = 1
            };

            var user = new AppUser { Id = userId, FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = UserStatus.Active, DepartmentId = 1 };
            _userServiceMock.Setup(x => x.GetUserByIds(userId))
                .ReturnsAsync(user);

            _userServiceMock.Setup(x => x.EditAsync(It.IsAny<AppUser>()))
                .ReturnsAsync("Success");

            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Should().Be(_localizerMock.Object[SharedResourcesKeys.Updated]);
            _userServiceMock.Verify(x => x.GetUserByIds(userId), Times.Once);
            _userServiceMock.Verify(x => x.EditAsync(It.IsAny<AppUser>()), Times.Once);
        }

        // ==========================================================================

        [Fact]
        public async Task Handle_DeleteUser_Should_Return_SuccessResponse_200()
        {
            Thread.Sleep(3000);
            // Arrange
            var userId = 1;
            var request = new DeleteUserCommand(userId)
            {
                Id = userId
            };

            var user = new AppUser { Id = userId, FirstName = "Ameen", LastName = "Hameed", Email = "ameen@gmail.com", UserName = "ameen@gmail.com", Password = "Ameen@000", Status = UserStatus.Active, DepartmentId = 1 };
            _userServiceMock.Setup(x => x.GetUserByIds(userId))
                .ReturnsAsync(user);

            _userServiceMock.Setup(x => x.DeleteAsync(user))
                .ReturnsAsync("Success");


            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            _userServiceMock.Verify(x => x.GetUserByIds(userId), Times.Once);
            _userServiceMock.Verify(x => x.DeleteAsync(user), Times.Once);
        }

        [Fact]
        public async Task Handle_DeleteUser_Should_Return_NotFoundResponse_404()
        {
            Thread.Sleep(3000);

            // Arrange
            var userId = 1;
            var request = new DeleteUserCommand(userId)
            {
                Id = userId
            };

            AppUser user = null;
            _userServiceMock.Setup(x => x.GetUserByIds(userId))
                .ReturnsAsync(user);

            var handler = new UserCommandHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            _userServiceMock.Verify(x => x.GetUserByIds(userId), Times.Once);
            _userServiceMock.Verify(x => x.DeleteAsync(It.IsAny<AppUser>()), Times.Never);
        }
    }
}
