using System.Collections.Generic;

namespace AniDB.Application.UseCases.Tables.Queries.GetTablesList
{
    public class TablesListModel
    {
        public IList<TableLookupModel> Tables { get; set; }
    }
}
