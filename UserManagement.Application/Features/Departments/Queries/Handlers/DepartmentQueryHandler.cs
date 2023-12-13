using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Departments.Queries.Models;
using UserManagement.Application.Features.Departments.Queries.Results;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListResponse>>>,
        IRequestHandler<GetDepartmentByIdQuery, Response<GitSingleDepartmentResponse>>
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        #endregion


        #region Constractors
        public DepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        #endregion

        #region Handles Functions
        public async Task<Response<List<GetDepartmentListResponse>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentList = await _departmentRepository.GetDepartmentsListAsync();
            var departmentListMapper = _mapper.Map<List<GetDepartmentListResponse>>(departmentList);
            return Success(departmentListMapper);
        }

        public async Task<Response<GitSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(request.Id);
            if (department == null) return NotFound<GitSingleDepartmentResponse>("Department Not Found");
            var result = _mapper.Map<GitSingleDepartmentResponse>(department);
            return Success(result);
        }
        #endregion
    }
}
