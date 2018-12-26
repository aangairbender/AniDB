using System;
using System.IO;
using AniDB.Domain.Infrastructure;
using AniDB.Domain.ValueObjects;

namespace AniDB.Domain.Entities
{
    public class TableColumn<T> : TableColumn
        where T : TableValue
    {
        public Type Type => typeof(T);

        public override string TypeDescription => TableValue.SupportedTypes[Type];
    }

    public abstract class TableColumn : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public abstract string TypeDescription { get; }

        public TableColumn()
        {
            Id = Guid.NewGuid();
        }
    }
}
