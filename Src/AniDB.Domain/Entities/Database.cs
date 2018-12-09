using System.Collections.Generic;

namespace AniDB.Domain.Entities
{
    public class Database
    {
        public string Name { get; set; }

        public ICollection<Table> Tables { get; }

        public Database()
        {
            Tables = new List<Table>();
        }
    }
}
