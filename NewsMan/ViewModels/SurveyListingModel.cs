using NewsMan.Data.Models;

namespace NewsMan.ViewModels
{
    public class SurveyListingModel
    {
        public int Id { get; set; }
        public QMaster QMaster { get; set; }
        public string SessionId { get; set; }
        public int Answer { get; set; }
        public string AnswerText { get; set; }
    }
}
