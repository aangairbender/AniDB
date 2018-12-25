using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.RenameColumn
{
    public class RenameColumnCommand : IRequest
    {
        public Guid TableId { get; set; }
        public Guid ColumnId { get; set; }
        public string NewName { get; set; }
    }
}
