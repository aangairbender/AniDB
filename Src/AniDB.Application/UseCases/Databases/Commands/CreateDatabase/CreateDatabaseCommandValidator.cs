using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace AniDB.Application.UseCases.Databases.Commands.CreateDatabase
{
    public class CreateDatabaseCommandValidator : AbstractValidator<CreateDatabaseCommand>
    {
        public CreateDatabaseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
        }
    }
}
