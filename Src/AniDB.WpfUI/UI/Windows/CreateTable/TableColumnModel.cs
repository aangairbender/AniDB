using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.Domain.Entities;
using AniDB.Domain.Entities.TableValues;
using AniDB.Domain.ValueObjects;

namespace AniDB.WpfUI.UI.Windows.CreateTable
{
    public class TableColumnModel
    {
        public string Name { get; set; } = "Default name";
        public string Type { get; set; } = TableValue.SupportedTypes[typeof(StringTableValue)];
    }
}
