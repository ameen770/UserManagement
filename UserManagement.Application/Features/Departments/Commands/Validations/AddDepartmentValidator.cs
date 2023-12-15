using FluentValidation;
using Microsoft.Extensions.Localization;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Application.Resources;
using UserManagement.Application.Services;

namespace UserManagement.Application.Features.Departments.Commands.Validatiors
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public AddDepartmentValidator(IDepartmentService departmentService, IStringLocalizer<SharedResources> localizer)
        {
            _departmentService = departmentService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _departmentService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion

    }
}
