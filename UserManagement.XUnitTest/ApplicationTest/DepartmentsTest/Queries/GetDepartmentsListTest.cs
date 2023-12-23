using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Departments.Queries.Handlers;
using UserManagement.Application.Features.Departments.Queries.Models;
using UserManagement.Application.Features.Departments.Queries.Results;
using UserManagement.Application.Mapping.Departments;
using UserManagement.Application.IServices;
using UserManagement.Domain.Entities;

namespace UserManagement.XUnitTest.ApplicationTest.DepartmentsTest.Queries
{
    public class GetUsersListTest
    {
        private readonly Mock<IDepartmentService> _departmentServiceMock;
        private readonly IMapper _mapperMock;
        private readonly DepartmentProfile _departmentProfile;

        public GetUsersListTest()
        {
            _departmentServiceMock = new();
            _departmentProfile = new();
            var configratin = new MapperConfiguration(c => c.AddProfile(_departmentProfile));
            _mapperMock = new Mapper(configratin);
        }

        [Fact]
        public async Task Handle_DepartmentsList_Should_NotNull_And_NotEmpty()
        {
            Thread.Sleep(3000);

            //Arrange
            var departmentList = new List<Department>() 
            {
                new Department() {Id=1, Name="Unit Test"}
            };
            var query = new GetDepartmentsListQuery();
            _departmentServiceMock.Setup(d => d.GetDepartmentsLists()).Returns(Task.FromResult(departmentList));
            var handle = new DepartmentQueryHandler(_departmentServiceMock.Object, _mapperMock);

            //Act
            var result = await handle.Handle(query, default);
            
            //Assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Data.Should().BeOfType<List<GetDepartmentsListResponse>>();
            result.Succeeded.Should().BeTrue();
        }
    }
}
