using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Tables.Commands.SwapColumnIndices
{
    public class SwapColumnIndicesCommand : IRequest
    {
        public Guid TableId { get; set; }
        public Guid ColumnAId { get; set; }
        public Guid ColumnBId { get; set; }
    }
}
