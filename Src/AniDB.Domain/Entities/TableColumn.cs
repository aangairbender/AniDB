using System;
using AniDB.Domain.Infrastructure;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities
{
    public class TableColumn<T> : TableColumn
        where T : TableValue
    {
        public Type Type => typeof(T);
    }

    public abstract class TableColumn : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TableColumn()
        {
            Id = new Guid();
        }
    }
}
