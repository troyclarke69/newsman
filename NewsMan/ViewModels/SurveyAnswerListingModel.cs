namespace NewsMan.ViewModels
{
    public class SurveyAnswerListingModel
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public int Val { get; set; }
        public string AnswerText { get; set; }
        public int Votes { get; set; }
        public decimal Percentage { get; set; }
    }
}
