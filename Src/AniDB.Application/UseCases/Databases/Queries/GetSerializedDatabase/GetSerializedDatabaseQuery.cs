using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Databases.Queries.GetSerializedDatabase
{
    public class GetSerializedDatabaseQuery : IRequest<string>
    {
        public Guid DatabaseId { get; set; }
    }
}
