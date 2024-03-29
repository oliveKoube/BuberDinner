﻿using FluentValidation;

namespace BuberDinner.Application.Menus.CreateMenu;

internal sealed class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
    }
}
