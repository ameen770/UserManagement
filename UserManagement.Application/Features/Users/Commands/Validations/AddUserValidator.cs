using FluentValidation;
using Microsoft.Extensions.Localization;
using UserManagement.Application.Features.Users.Commands.Models;
using UserManagement.Application.Resources;
using UserManagement.Application.Services;

namespace UserManagement.Application.Features.Users.Commands.Validatiors
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IAppUserService _appUserService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructors
        public AddUserValidator(IAppUserService appUserService, IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService)
        {
            _appUserService = appUserService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _departmentService = departmentService;
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.DepartmentId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (Key, CancellationToken) => !await _appUserService.IsEmailExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartmentId)
               .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion

    }
}
