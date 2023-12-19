using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Users.Commands.Models;
using UserManagement.Application.Resources;
using UserManagement.Domain.Entities;
using UserManagement.Application.IServices;

namespace UserManagement.Application.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                       IRequestHandler<AddUserCommand, Response<string>>,
                                       IRequestHandler<EditUserCommand, Response<string>>,
                                       IRequestHandler<DeleteUserCommand, Response<string>>
    {
        #region Fields
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public UserCommandHandler(IAppUserService appUserService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) //: base(localizer)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion


        #region Handle Functions

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and User
            var appUsermapper = _mapper.Map<AppUser>(request);
            //add
            var result = await _appUserService.AddAsync(appUsermapper);
            //return response
            if (result=="Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var appUser = await _appUserService.GetUserByIds(request.Id);
            //return NotFound
            if (appUser == null) return NotFound<string>();
            //mapping Between request and User
            var appUsermapper = _mapper.Map(request, appUser);
            //Call service that make Edit
            var result = await _appUserService.EditAsync(appUsermapper);
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var appUser = await _appUserService.GetUserByIds(request.Id);
            //return NotFound
            if (appUser == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _appUserService.DeleteAsync(appUser);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion

    }
}
