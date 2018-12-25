using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.ModifyTableValue
{
    public class ModifyTableValueCommand : IRequest
    {
        public Guid TableId { get; set; }
        public Guid TableRowId { get; set; }
        public Guid TableValueId { get; set; }
        public string NewValue { get; set; }
    }
}
