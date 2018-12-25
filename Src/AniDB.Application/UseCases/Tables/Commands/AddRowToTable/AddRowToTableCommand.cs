using System;
using System.Collections.Generic;
using System.Text;
using AniDB.Domain.Entities;
using AniDB.Domain.ValueObjects;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.AddRowToTable
{
    public class AddRowToTableCommand : IRequest
    {
        public Guid TableId { get; set; }

        public TableValue[] Values { get; set; }

    }
}
