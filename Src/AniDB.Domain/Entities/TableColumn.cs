using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.Entities
{
    public class TableColumn<T> : TableColumn
        where T : TableValue
    {

    }

    public abstract class TableColumn
    {
        public string Name { get; set; }
    }
}
