namespace NewsMan.Data.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public QMaster QMaster { get; set; }
        public string SessionId { get; set; }
        public int Answer { get; set; }
    }
}
