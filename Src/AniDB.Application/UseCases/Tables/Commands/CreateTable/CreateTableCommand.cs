using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.ValueObjects;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.CreateTable
{
    public class CreateTableCommand : IRequest
    {
        public string Name { get; set; }

        public Guid DatabaseId { get; set; }

        public IDictionary<string, Type> Columns { get; set; }
    }
}
