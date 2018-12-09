using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniDB.Application.UseCases.Databases.Commands.CreateDatabase
{
    public class CreateDatabaseCommand : IRequest
    {
        public string Name { get; set; }
    }
}
