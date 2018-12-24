using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AniDB.Domain.Entities;

namespace AniDB.Application.Infrastructure
{
    public interface IRepository
    {
        Task<List<Database>> GetDatabases();
        Task AddDatabase(Database database);
        Task<bool> DatabaseExistsWithName(string name);

        Task<List<Table>> GetTables(Guid databaseId);
        Task<ICollection<TableRow>> GetTableData(Guid tableId);
        Task<TableSchema> GetTableSchema(Guid tableId);
    }
}
