using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.DeleteTable
{
    public class DeleteTableCommand : IRequest
    {
        public Guid TableId { get; set; }
    }
}
