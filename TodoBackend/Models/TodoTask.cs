namespace TodoBackend.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Think" ;
        public bool IsCompleted { get; set; } = false ;
    }
}