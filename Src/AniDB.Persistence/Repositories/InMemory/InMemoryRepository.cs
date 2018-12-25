using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Domain.Entities;
using AniDB.Domain.Entities.TableValues;
using AniDB.Domain.ValueObjects;

namespace AniDB.Persistence.Repositories.InMemory
{
    public class InMemoryRepository : IRepository
    {
        private readonly IDictionary<Guid, Database> _databases;

        private void GenerateDemoRepository()
        {
            var db1 = new Database {Name = "University"};
            var tableSchema1 = new TableSchema(new List<TableColumn>
                {
                    new TableColumn<StringTableValue> {Name = "Name"},
                    new TableColumn<StringTableValue> {Name = "Surname"},
                    new TableColumn<IntegerTableValue> {Name = "Score"}
                }
            );
            var table1 = new Table {Name = "Students", Schema = tableSchema1};
            table1.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Yevhen"),
                new StringTableValue("Kazmin"),
                new IntegerTableValue(100)
            }));
            table1.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Stepan"),
                new StringTableValue("Galushko"),
                new IntegerTableValue(40)
            }));
            table1.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Oleg"),
                new StringTableValue("Petrenko"),
                new IntegerTableValue(68)
            }));
            db1.AddTable(table1);

            var tableSchema2 = new TableSchema(new List<TableColumn>
                {
                    new TableColumn<StringTableValue> {Name = "Title"},
                }
            );
            var table2 = new Table { Name = "Subjects", Schema = tableSchema2 };
            table2.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Math"),
            }));
            table2.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Computer science"),
            }));
            table2.AddRow(new TableRow(new List<TableValue>
            {
                new StringTableValue("Philosophy"),
            }));
            db1.AddTable(table2);
            _databases.Add(db1.Id, db1);
        }

        public InMemoryRepository()
        {
            _databases = new Dictionary<Guid, Database>();
            GenerateDemoRepository();
        }

        public Task<List<Database>> GetDatabases()
        {
            return Task.Run(() => _databases.Values.ToList());
        }


        public Task<Database> GetDatabase(Guid databaseId)
        {
            return Task.Run(() => _databases.FirstOrDefault(d => d.Key == databaseId).Value);
        }

        public Task<List<Table>> GetTables(Guid databaseId)
        {
            return Task.Run(() => _databases.Values.First(x => x.Id == databaseId).Tables.ToList());
        }

        public Task<ICollection<TableRow>> GetTableData(Guid tableId)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables.First(t => t.Id == tableId)
                    .Data);
        }

        public Task<TableSchema> GetTableSchema(Guid tableId)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables.First(t => t.Id == tableId)
                    .Schema);
        }

        public Task<bool> TableExistsWithName(Guid databaseId, string name)
        {
            return Task.Run(() => _databases[databaseId].Tables.Any(t => t.Name.Equals(name)));
        }

        public Task AddTable(Guid databaseId, Table table)
        {
            return Task.Run(() => _databases[databaseId].AddTable(table));
        }

        public Task DeleteTable(Guid tableId)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).DeleteTable(tableId));
        }

        public Task AddRowToTable(Guid tableId, TableRow tableRow)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables.First(t => t.Id == tableId)
                    .AddRow(tableRow));
        }

        public Task ModifyTableValue(Guid tableId, Guid tableRowId, Guid tableValueId, string newValue)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables.First(t => t.Id == tableId)
                    .Data.First(x => x.Id == tableRowId).Values.First(x => x.Id == tableValueId).FromString(newValue));
        }

        public Task RenameColumn(Guid tableId, Guid columnId, string newName)
        {
            return Task.Run(() =>
                _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables.First(t => t.Id == tableId)
                    .Schema.Columns.First(x => x.Id == columnId).Name = newName);
        }

        public Task SwapColumnIndices(Guid tableId, Guid columnAId, Guid columnBId)
        {
            return Task.Run(() =>
            {
                var table = _databases.Values.First(x => x.Tables.Any(t => t.Id == tableId)).Tables
                    .First(t => t.Id == tableId);
                table.SwapColumns(columnAId, columnBId);
            });
        }

        public Task AddDatabase(Database database)
        {
            return Task.Run(() =>
            {
                _databases.Add(database.Id, database);
            });
        }


        public Task<bool> DatabaseExistsWithName(string name)
        {
            return Task.Run(() => _databases.Values.Any(x => x.Name == name));
        }
    }
}
