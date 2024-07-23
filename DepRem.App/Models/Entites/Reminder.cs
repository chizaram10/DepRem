namespace DepRem.App.Models.Entites
{
    public class Reminder : BaseEntity
    {
#nullable disable
        public string Title { get; set; }
        public DateTime DateTimeForExecution { get; set; }
    }
}
