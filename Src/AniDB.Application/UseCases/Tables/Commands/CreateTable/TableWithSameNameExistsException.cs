using System;
using System.Collections.Generic;
using System.Text;

namespace AniDB.Application.UseCases.Tables.Commands.CreateTable
{
    public class TableWithSameNameExistsException : Exception
    {
        public TableWithSameNameExistsException(string name)
            : base($"Table with name {name} already exists.")
        { 
        }
    }
}
