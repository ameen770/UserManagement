using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Users.Queries.Models;
using UserManagement.Application.Features.Users.Queries.Results;
using UserManagement.Application.Resources;
using UserManagement.Application.IServices;

namespace UserManagement.Application.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUsersListQuery, Response<List<GetUsersListResponse>>>,
        IRequestHandler<GetUserByIdQuery, Response<GetSingleUserResponse>>
    {
        #region Fields
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion


        #region Constractors
        public UserQueryHandler(IAppUserService appUserService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _appUserService = appUserService;// ?? throw new ArgumentNullException(nameof(departmentService));
            _mapper = mapper;// ?? throw new ArgumentNullException(nameof(mapper));
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handles Functions
        public async Task<Response<List<GetUsersListResponse>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var appUserList = await _appUserService.GetUsersLists();
            var appUserListMapper = _mapper.Map<List<GetUsersListResponse>>(appUserList);
            var result = Success(appUserListMapper);
            result.Meta = new { Count = appUserListMapper.Count() };
            return result;
        }

        public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserService.GetUserByIds(request.Id);
            if (appUser == null) return NotFound<GetSingleUserResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetSingleUserResponse>(appUser);
            return Success(result);
        }
        #endregion
    }
}
