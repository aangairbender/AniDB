using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Databases.Commands.LoadSerializedDatabase
{
    public class LoadSerializedDatabaseCommand : IRequest
    {
        public string Content { get; set; }
    }
}
