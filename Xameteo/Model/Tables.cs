using System.Collections.ObjectModel;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public interface ITableProvider
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        TableGroup GenerateTable();
    }

    /// <summary>
    /// </summary>
    public class TableItem
    {
        /// <summary>
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public TableItem(string title, string description)
        {
            Title = title;
            Description = description.Trim().Length > 0 ? description : "N/A";
        }
    }

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