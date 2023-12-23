using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using UserManagement.Application.Features.Departments.Commands.Handlers;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Application.Mapping.Departments;
using UserManagement.Application.Resources;
using UserManagement.Domain.Entities;
using UserManagement.Application.IServices;
using System.Net;

namespace UserManagement.XUnitTest.ApplicationTest.DepartmentsTest.Commands
{
    public class DepartmentCommandHandlerTest
    {
        private readonly Mock<IDepartmentService> _departmentServiceMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;
        private readonly DepartmentProfile _departmentProfile;


        public DepartmentCommandHandlerTest()
        {
            _departmentProfile = new();
            _departmentServiceMock = new();
            _localizerMock = new();
            var configuration = new MapperConfiguration(c => c.AddProfile(_departmentProfile));
            _mapperMock=new Mapper(configuration);
        }

        // ==========================================================================


        [Fact]
        public async Task Handle_AddDepartment_Should_Add_Data_And_StatusCode201()
        {
            Thread.Sleep(3000);

            //Arrange
            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);
            var addDepartmentCommand = new AddDepartmentCommand() { Name="Unit Test" };
            _departmentServiceMock.Setup(x => x.AddAsync(It.IsAny<Department>())).Returns(Task.FromResult("Success"));
            //act
            var result = await handler.Handle(addDepartmentCommand, default);
            //Assert
            result.Succeeded.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            _departmentServiceMock.Verify(x => x.AddAsync(It.IsAny<Department>()), Times.Once, "Not Called");
        }

        [Fact]
        public async Task Handle_AddDepartment_Should_return_StatusCode400()
        {
            Thread.Sleep(3000);

            //Arrange
            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);
            var addDepartmentCommand = new AddDepartmentCommand() { Name = "Unit Test" };
            _departmentServiceMock.Setup(x => x.AddAsync(It.IsAny<Department>())).Returns(Task.FromResult(""));
            //Act
            var result = await handler.Handle(addDepartmentCommand, default);
            //Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _departmentServiceMock.Verify(x => x.AddAsync(It.IsAny<Department>()), Times.Once, "Not Called");
        }

        // ==========================================================================

        /*[Fact]
        public async Task Handle_EditDepartment_Should_Return_NotFoundResponse_404()
        {
            //Arrange
            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);
            var updateDepartmentCommand = new EditDepartmentCommand() { Id = 6, Name = "Unit Test" };
            Department department = null;
            int xResult = 0;
            _departmentServiceMock.Setup(x => x.GetDepartmentByIds(updateDepartmentCommand.Id)).Returns(Task.FromResult(department)).Callback((int x) => xResult = x);
            //Act
            var result = await handler.Handle(updateDepartmentCommand, default);
            //Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            xResult.Should().Be(6);
            Assert.Equal(xResult, updateDepartmentCommand.Id);
            _departmentServiceMock.Verify(x => x.GetDepartmentByIds(It.IsAny<int>()), Times.Once, "Not Called");
        }*/

        [Fact]
        public async Task Handle_EditDepartment_Should_Return_NotFoundResponse_404()
        {
            Thread.Sleep(3000);

            // Arrange
            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);
            var updateDepartmentCommand = new EditDepartmentCommand { Id = 6, Name = "Unit Test" };
            Department department = null;

            _departmentServiceMock.Setup(x => x.GetDepartmentByIds(updateDepartmentCommand.Id)).ReturnsAsync(department);

            // Act
            var result = await handler.Handle(updateDepartmentCommand, default);

            // Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            _departmentServiceMock.Verify(x => x.GetDepartmentByIds(updateDepartmentCommand.Id), Times.Once);
            _departmentServiceMock.Verify(x => x.EditAsync(It.IsAny<Department>()), Times.Never);
        }


        [Fact]
        public async Task Handle_EditDepartment_Should_Return_SuccessResponse_200()
        {
            Thread.Sleep(3000);

            // Arrange
            var departmentId = 1;
            var request = new EditDepartmentCommand
            {
                Id = departmentId,
                Name = "Updated Department"
            };

            var department = new Department { Id = departmentId, Name = "Existing Department" };
            _departmentServiceMock.Setup(x => x.GetDepartmentByIds(departmentId))
                .ReturnsAsync(department);

            _departmentServiceMock.Setup(x => x.EditAsync(It.IsAny<Department>()))
                .ReturnsAsync("Success");

            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Should().Be(_localizerMock.Object[SharedResourcesKeys.Updated]);
            _departmentServiceMock.Verify(x => x.GetDepartmentByIds(departmentId), Times.Once);
            _departmentServiceMock.Verify(x => x.EditAsync(It.IsAny<Department>()), Times.Once);
        }

        // ==========================================================================

        [Fact]
        public async Task Handle_DeleteDepartment_Should_Return_SuccessResponse_200()
        {
            Thread.Sleep(3000);
            // Arrange
            var departmentId = 1;
            var request = new DeleteDepartmentCommand(departmentId)
            {
                Id = departmentId
            };

            var department = new Department { Id = departmentId, Name = "Existing Department" };
            _departmentServiceMock.Setup(x => x.GetDepartmentByIds(departmentId))
                .ReturnsAsync(department);

            _departmentServiceMock.Setup(x => x.DeleteAsync(department))
                .ReturnsAsync("Success");


            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            _departmentServiceMock.Verify(x => x.GetDepartmentByIds(departmentId), Times.Once);
            _departmentServiceMock.Verify(x => x.DeleteAsync(department), Times.Once);
        }

        [Fact]
        public async Task Handle_DeleteDepartment_Should_Return_NotFoundResponse_404()
        {
            Thread.Sleep(3000);

            // Arrange
            var departmentId = 1;
            var request = new DeleteDepartmentCommand(departmentId)
            {
                Id = departmentId
            };

            Department department = null;
            _departmentServiceMock.Setup(x => x.GetDepartmentByIds(departmentId))
                .ReturnsAsync(department);

            var handler = new DepartmentCommandHandler(_departmentServiceMock.Object, _mapperMock, _localizerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            _departmentServiceMock.Verify(x => x.GetDepartmentByIds(departmentId), Times.Once);
            _departmentServiceMock.Verify(x => x.DeleteAsync(It.IsAny<Department>()), Times.Never);
        }
    }
}
