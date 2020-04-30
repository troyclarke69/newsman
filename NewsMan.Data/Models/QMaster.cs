namespace NewsMan.Data.Models
{
    public class QMaster
    {
        public int Id { get; set; }
        public int Level { get; set; } //1 = pre, 2 = post
        public int Order { get; set; }
        public string Question { get; set; }
        public int Key { get; set; }
    }
}
