using System;
using AniDB.Domain.Infrastructure;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities
{
    public class TableColumn<T> : TableColumn
        where T : TableValue
    {

    }

    public abstract class TableColumn : IEntity
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public TableColumn()
        {
            Id = new Guid();
        }
    }
}
