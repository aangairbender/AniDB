using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace AniDB.Application.UseCases.Tables.Commands.CreateTable
{
    public class CreateTableCommandColumnsValidator : AbstractValidator<KeyValuePair<string, Type>>
    {
        public CreateTableCommandColumnsValidator()
        {
            RuleFor(kvp => kvp.Key).NotEmpty();
        }
    }
}
