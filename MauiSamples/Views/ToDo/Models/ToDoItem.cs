using SQLite;

namespace MauiSamples.Views.ToDo.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; } = false;
    }
}
