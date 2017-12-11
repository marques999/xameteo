using System.Collections.ObjectModel;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TableGroup : ObservableCollection<TableItem>
    {
        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        public TableGroup(string name)
        {
            Name = name;
        }
    }
}