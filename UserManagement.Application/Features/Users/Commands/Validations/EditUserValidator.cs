using FluentValidation;
using Microsoft.Extensions.Localization;
using UserManagement.Application.Features.Users.Commands.Models;
using UserManagement.Application.Resources;
using UserManagement.Application.Services;

namespace UserManagement.Application.Features.Users.Commands.Validatiors
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly IAppUserService _appUserService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditUserValidator(IAppUserService appUserService,
                                    IStringLocalizer<SharedResources> localizer)
        {
            _appUserService = appUserService;
            _localizer=localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (model, Key, CancellationToken) => !await _appUserService.IsEmailExistExcludeSelf(Key, model.Id))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
