using AutoMapper;
using MediatR;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Departments.Queries.Models;
using UserManagement.Application.Features.Departments.Queries.Results;
using UserManagement.Application.Services;

namespace UserManagement.Application.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentsListQuery, Response<List<GetDepartmentsListResponse>>>,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetSingleDepartmentResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        #endregion


        #region Constractors
        public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;// ?? throw new ArgumentNullException(nameof(departmentService));
            _mapper = mapper;// ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Handles Functions
        public async Task<Response<List<GetDepartmentsListResponse>>> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var departmentList = await _departmentService.GetDepartmentsLists();
            var departmentListMapper = _mapper.Map<List<GetDepartmentsListResponse>>(departmentList);
            return Success(departmentListMapper);
        }

        public async Task<Response<GetSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIds(request.Id);
            if (department == null) return NotFound<GetSingleDepartmentResponse>("Department Not Found");
            var result = _mapper.Map<GetSingleDepartmentResponse>(department);
            return Success(result);
        }
        #endregion
    }
}
