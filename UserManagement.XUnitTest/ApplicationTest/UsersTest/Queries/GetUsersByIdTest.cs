using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Users.Queries.Handlers;
using UserManagement.Application.Features.Users.Queries.Models;
using UserManagement.Application.Features.Users.Queries.Results;
using UserManagement.Application.Mapping.Users;
using UserManagement.Application.IServices;
using UserManagement.Domain.Entities;
using UserManagement.XUnitTest.TestModel;
using Microsoft.Extensions.Localization;
using UserManagement.Application.Resources;
using UserManagement.Domain.Enum;

// Use Parallel Test
// [assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, MaxParallelThreads = 6)]
namespace UserManagement.XUnitTest.ApplicationTest.UsersTest.Queries
{
    public class GetUsersByIdTest
    {
        private readonly Mock<IAppUserService> _userServiceMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;
        private readonly UserProfile _userProfile;

        public GetUsersByIdTest()
        {
            _userServiceMock = new();
            _userProfile = new();
            _localizerMock = new();
            var configratin = new MapperConfiguration(c => c.AddProfile(_userProfile));
            _mapperMock = new Mapper(configratin);
        }

        [Theory]
        [InlineData(5)]
        public async Task Handle_User_By_Id_Should_NotFound_Return_404(int id)
        {
            Thread.Sleep(3000);

            //Arrange
            var department = new Department()
            {
                Id=1, Name="Unit Test"
            };

            var userList = new List<AppUser>() 
            {
                new AppUser() {Id=1, FirstName="Ameen", LastName="Hameed", Email="ameen@gmail.com", UserName="ameen@gmail.com", Password="Ameen@000", Status=UserStatus.Active, DepartmentId=1, Department=department},
                new AppUser() {Id=2, FirstName="Salah", LastName="Mohammed", Email="salah@gmail.com", UserName="salah@gmail.com", Password="Salah@000", Status=UserStatus.Active, DepartmentId=1, Department=department},
                new AppUser() {Id=3, FirstName="Ahmed", LastName="Ali", Email="ahmed@gmail.com", UserName="ahmed@gmail.com", Password="Ahmed@000", Status=UserStatus.Active, DepartmentId = 1, Department=department}
            };

            var query = new GetUserByIdQuery(id);
            _userServiceMock.Setup(d => d.GetUserByIds(id)).Returns(Task.FromResult(userList.FirstOrDefault(x => x.Id == id)));
            var handle = new UserQueryHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            //Act
            var result = await handle.Handle(query, default);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Data.Should().BeNull();
            result.Succeeded.Should().BeFalse();
        }
        
        [Theory]
        //[InlineData(1)]
        //[ClassData(typeof(PassDataByClassData))]
        [MemberData(nameof(PassDataByMemberData.GetDataParam), MemberType = typeof(PassDataByMemberData))]
        public async Task Handle_User_By_Id_Should_Found_Return_200(int id)
        {
            Thread.Sleep(3000);

            //Arrange
            var department = new Department()
            {
                Id = 1,
                Name = "Unit Test"
            };

            var userList = new List<AppUser>()
            {
                new AppUser() {Id=1, FirstName="Ameen", LastName="Hameed", Email="ameen@gmail.com", UserName="ameen@gmail.com", Password="Ameen@000", Status=UserStatus.Active, Department=department},
                new AppUser() {Id=2, FirstName="Salah", LastName="Mohammed", Email="salah@gmail.com", UserName="salah@gmail.com", Password="Salah@000", Status=UserStatus.Active, Department=department},
                new AppUser() {Id=3, FirstName="Ahmed", LastName="Ali", Email="ahmed@gmail.com", UserName="ahmed@gmail.com", Password="Ahmed@000", Status=UserStatus.Active, Department=department}
            };

            var query = new GetUserByIdQuery(id);
            _userServiceMock.Setup(d => d.GetUserByIds(id)).Returns(Task.FromResult(userList.FirstOrDefault(x => x.Id == id)));
            var handle = new UserQueryHandler(_userServiceMock.Object, _mapperMock, _localizerMock.Object);

            //Act
            var result = await handle.Handle(query, default);

            //Assert
            result.Data.Id.Should().Be(id);
            result.Data.Email.Should().Be(userList.FirstOrDefault(d => d.Id == id).Email);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Should().BeOfType<GetSingleUserResponse>();
            result.Succeeded.Should().BeTrue();
        }
    }
}
