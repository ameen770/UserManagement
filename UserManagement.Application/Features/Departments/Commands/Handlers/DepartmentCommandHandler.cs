using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Application.Resources;
using UserManagement.Domain.Entities;
using UserManagement.Application.Services;

namespace UserManagement.Application.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponseHandler,
                                       IRequestHandler<AddDepartmentCommand, Response<string>>,
                                       IRequestHandler<EditDepartmentCommand, Response<string>>,
                                       IRequestHandler<DeleteDepartmentCommand, Response<string>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public DepartmentCommandHandler(IDepartmentService departmentService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) //: base(localizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion


        #region Handle Functions

        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and Department
            var departmentmapper = _mapper.Map<Department>(request);
            //add
            var result = await _departmentService.AddAsync(departmentmapper);
            //return response
            if (result=="Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var department = await _departmentService.GetDepartmentByIds(request.Id);
            //return NotFound
            if (department == null) return NotFound<string>();
            //mapping Between request and department
            var departmentmapper = _mapper.Map(request, department);
            //Call service that make Edit
            var result = await _departmentService.EditAsync(departmentmapper);
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var department = await _departmentService.GetDepartmentByIds(request.Id);
            //return NotFound
            if (department == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _departmentService.DeleteAsync(department);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion

    }
}
