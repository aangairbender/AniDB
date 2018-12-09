using System;
using System.Collections.Generic;
using System.Text;

namespace AniDB.Application.UseCases.Databases.Commands.CreateDatabase
{
    public class DatabaseWithSameNameExistsException : Exception
    {
        public DatabaseWithSameNameExistsException(string name)
            : base($"Database with name {name} already exists.")
        {
        }
    }
}
