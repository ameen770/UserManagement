using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Departments.Queries.Handlers;
using UserManagement.Application.Features.Departments.Queries.Models;
using UserManagement.Application.Features.Departments.Queries.Results;
using UserManagement.Application.Mapping.Departments;
using UserManagement.Application.IServices;
using UserManagement.Domain.Entities;
using UserManagement.XUnitTest.TestModel;

// Use Parallel Test
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, MaxParallelThreads = 6)]
namespace UserManagement.XUnitTest.ApplicationTest.DepartmentsTest.Queries
{
    public class GetDepartmentsByIdTest
    {
        private readonly Mock<IDepartmentService> _departmentServiceMock;
        private readonly IMapper _mapperMock;
        private readonly DepartmentProfile _departmentProfile;

        public GetDepartmentsByIdTest()
        {
            _departmentServiceMock = new();
            _departmentProfile = new();
            var configratin = new MapperConfiguration(c => c.AddProfile(_departmentProfile));
            _mapperMock = new Mapper(configratin);
        }

        [Theory]
        [InlineData(5)]
        public async Task Handle_Department_By_Id_Should_NotFound_Return_404(int id)
        {
            Thread.Sleep(3000);

            var departmentList = new List<Department>() 
            {
                new Department() {Id=1, Name="Unit Test"},
                new Department() {Id=2, Name="Software Engineering"},
                new Department() {Id=3, Name="System Developers"}
            };

            var query = new GetDepartmentByIdQuery(id);
            _departmentServiceMock.Setup(d => d.GetDepartmentByIds(id)).Returns(Task.FromResult(departmentList.FirstOrDefault(x => x.Id == id)));
            var handle = new DepartmentQueryHandler(_departmentServiceMock.Object, _mapperMock);

            var result = await handle.Handle(query, default);

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Data.Should().BeNull();
            result.Succeeded.Should().BeFalse();
        }
        
        [Theory]
        //[InlineData(1)]
        //[ClassData(typeof(PassDataByClassData))]
        [MemberData(nameof(PassDataByMemberData.GetDataParam), MemberType = typeof(PassDataByMemberData))]
        public async Task Handle_Department_By_Id_Should_Found_Return_200(int id)
        {
            Thread.Sleep(3000);

            var departmentList = new List<Department>() 
            {
                new Department() {Id=1, Name="Unit Test"},
                new Department() {Id=2, Name="Software Engineering"},
                new Department() {Id=3, Name="System Developers"}
            };
            var query = new GetDepartmentByIdQuery(id);
            _departmentServiceMock.Setup(d => d.GetDepartmentByIds(id)).Returns(Task.FromResult(departmentList.FirstOrDefault(x => x.Id == id)));
            var handle = new DepartmentQueryHandler(_departmentServiceMock.Object, _mapperMock);

            var result = await handle.Handle(query, default);

            result.Data.Id.Should().Be(id);
            result.Data.DepartmentName.Should().Be(departmentList.FirstOrDefault(d => d.Id == id).Name);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Should().BeOfType<GetSingleDepartmentResponse>();
            result.Succeeded.Should().BeTrue();
        }

        /*[Fact]
        public void Test_1()
        {
            Thread.Sleep(3000);
        }
        
        [Fact]
        public void Test_2()
        {
            Thread.Sleep(5000);
        }*/
    }
}
