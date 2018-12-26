using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using AniDB.Domain.Entities.TableValues;
using Dapper;
using MySql.Data.MySqlClient;

namespace AniDB.Persistence.Repositories.MySql
{
    public class MySqlRepository : IRepository
    {
        private readonly MySqlConnection _connection;

        public MySqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                return _connection;
            }
        }
        public MySqlRepository()
        {
            string connectionString = "Server=localhost;Database=anidb;User Id=root;password=;";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        ~MySqlRepository()
        {
            _connection.Close();
        }

        public async Task<List<Database>> GetDatabases()
        {
            var result = await _connection.QueryAsync("select * from `databases`");
            return result.Select(x => (IDictionary<string, object>)x).Select(x => new Database
                    { Id = Guid.Parse((string)x["id"]), Name = (string)x["name"] })
                .ToList(); ;
        }

        public async Task AddDatabase(Database database)
        {
            var sql = "insert into `databases` (id, name) values (@id, @name)";
            await _connection.ExecuteAsync(sql, new { Id = database.Id.ToString(), Name = database.Name });
        }

        public async Task<bool> DatabaseExistsWithName(string name)
        {
            var sql = "select count(*) as cnt from `databases` where name=@name";
            var result = (IDictionary<string, object>)await _connection.QuerySingleAsync(sql, new { Name = name });
            return int.Parse(result["cnt"].ToString()) > 0;
        }

        public async Task<Database> GetDatabase(Guid databaseId)
        {
            var sql = "select * from `databases` where id=@Id";
            var result = (IDictionary<string, object>)await _connection.QuerySingleAsync(sql, new { Id = databaseId.ToString() });
            return new Database { Id = Guid.Parse((string)result["id"]), Name = (string)result["name"] };
        }

        public async Task<List<Table>> GetTables(Guid databaseId)
        {
            var sql = "select * from `tables` where database_id=@Id";
            var result = await _connection.QueryAsync(sql, new { Id = databaseId.ToString() });
            return result.Select(x => (IDictionary<string, object>)x).Select(x =>
                new Table { Id = Guid.Parse((string)x["id"]), Name = (string)x["name"] }).ToList();
        }

        public async Task<ICollection<TableRow>> GetTableData(Guid tableId)
        {
            var sql = "select * from `tablerows` where table_id=@Id";
            var result = await _connection.QueryAsync(sql, new { Id = tableId.ToString() });
            ICollection<TableRow> rows = new List<TableRow>();
            foreach (var itemDynamic in result)
            {
                var item = (IDictionary<string, object>)itemDynamic;
                var rowId = item["id"].ToString();
                var sql2 = "select * from `tablevalues` where tablerow_id=@Id";
                var result2 = await _connection.QueryAsync(sql2, new { Id = rowId });
                var values = result2.Select(x => (IDictionary<string, object>)x)
                    .Select(x => (TableValue)new StringTableValue(x["value"].ToString())).ToList();
                rows.Add(new TableRow(values));
            }

            return rows;
        }

        public async Task<TableSchema> GetTableSchema(Guid tableId)
        {
            var sql = "select * from `tableschemas` where table_id=@Id";
            var result = (IDictionary<string, object>)await Connection.QuerySingleAsync(sql, new { Id = tableId.ToString() });


            string schemaId = result["id"].ToString();
            var sql2 = "select * from `tablecolumns` where tableschema_id=@Id";
            var result2 = await Connection.QueryAsync(sql2, new { Id = schemaId });
            var columns = result2.Select(x => (IDictionary<string, object>)x)
                .Select(x => (TableColumn)new TableColumn<StringTableValue>
                    { Id = Guid.Parse(x["id"].ToString()), Name = x["name"].ToString() }).ToList();


            return new TableSchema(columns) { Id = Guid.Parse(schemaId) };
        }

        public async Task<bool> TableExistsWithName(Guid databaseId, string name)
        {
            var sql = "select count(*) as cnt from `tables` where database_id=@Id and name=@name";
            var result =
                (IDictionary<string, object>) await _connection.QuerySingleAsync(sql,
                    new {Id = databaseId.ToString(), Name = name});
            return int.Parse(result["cnt"].ToString()) > 0;
        }

        public Task AddTable(Guid databaseId, Table table)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTable(Guid tableId)
        {
            var sql = "delete from `tables` where id=@id";
            await _connection.ExecuteAsync(sql, new { Id = tableId.ToString()});
        }

        public Task AddRowToTable(Guid tableId, TableRow tableRow)
        {
            throw new NotImplementedException();
        }

        public Task ModifyTableValue(Guid tableId, Guid tableRowId, Guid tableValueId, string newValue)
        {
            throw new NotImplementedException();
        }

        public Task RenameColumn(Guid tableId, Guid columnId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task SwapColumnIndices(Guid tableId, Guid columnAId, Guid columnBId)
        {
            throw new NotImplementedException();
        }
    }
}
