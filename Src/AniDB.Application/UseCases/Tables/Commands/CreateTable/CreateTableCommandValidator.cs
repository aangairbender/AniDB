using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace AniDB.Application.UseCases.Tables.Commands.CreateTable
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Columns.Count).NotEmpty();
            RuleForEach(x => x.Columns).SetValidator(new CreateTableCommandColumnsValidator());
        }
    }
}
