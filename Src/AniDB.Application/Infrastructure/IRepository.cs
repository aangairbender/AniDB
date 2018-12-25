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
        Task<Database> GetDatabase(Guid databaseId);

        Task<List<Table>> GetTables(Guid databaseId);
        Task<ICollection<TableRow>> GetTableData(Guid tableId);
        Task<TableSchema> GetTableSchema(Guid tableId);
        Task<bool> TableExistsWithName(Guid databaseId, string name);
        Task AddTable(Guid databaseId, Table table);
        Task DeleteTable(Guid tableId);
        Task AddRowToTable(Guid tableId, TableRow tableRow);
        Task ModifyTableValue(Guid tableId, Guid tableRowId, Guid tableValueId, string newValue);
        Task RenameColumn(Guid tableId, Guid columnId, string newName);
        Task SwapColumnIndices(Guid tableId, Guid columnAId, Guid columnBId);
    }
}
