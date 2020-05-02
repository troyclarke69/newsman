using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Linq;

namespace NewsMan.Service.Services
{
    public class SeedService : ISeedService
    {
        private readonly NewsManDbContext _context;
        private readonly ISurveyMaster _surveyMaster;
        private readonly ISessionUser _sessionUser;
        private readonly IAnswerGroup _answerGroup;
        private readonly IAnswerOption _answerOption;
        private readonly IQuestion _question;
        private readonly ISurveyQuestion _surveyQuestion;
        private readonly IResult _result;

        public SeedService(NewsManDbContext context, ISurveyMaster surveyMaster,
                                ISessionUser sessionUser, IAnswerGroup answerGroup,
                                    IAnswerOption answerOption, IQuestion question, 
                                    ISurveyQuestion surveyQuestion, IResult result)
        {
            _context = context;
            _surveyMaster = surveyMaster;
            _sessionUser = sessionUser;
            _answerGroup = answerGroup;
            _answerOption = answerOption;
            _question = question;
            _surveyQuestion = surveyQuestion;
            _result = result;
        }


        // Add x surveys (recs) ... # specified in TestsController
        public int SeedSurveyMaster(int recs)
        {
            for (int i = 1; i <= recs; i++)
            {
                var row = new SurveyMaster
                {
                    Name = "Survey " + Convert.ToString(i),
                    Purpose = "This is the purpose of Survey " + Convert.ToString(i),
                    DateOpen = DateTime.Now,
                    DateClose = DateTime.Now.AddDays(30),
                    Active = 1
                };

                _surveyMaster.Add(row);

                // add 100 sessions for each survey...
                int result = SeedSessionUser(100, row);

            }

            //verify result
            int count = _surveyMaster.GetAll().Count();
            return count;
        }

        public int SeedSessionUser(int recs, SurveyMaster _surveyMaster)
        {
            // ex. 10 surveys * 100 sessions/ea. = 1000 records created here
            for (int i = 1; i <= recs; i++)
            {
                var row = new Session
                {
                    DateEntered = DateTime.Now,
                    Origin = "IP",
                    SurveyMaster = _surveyMaster
                };

                _sessionUser.Add(row);
            }

            //verify result
            int count = _sessionUser.GetAll().Count();
            return count;
        }

        public int SeedAnswerGroup(int recs)
        {
            // suggested recs: 5 -- specified in TestsController
            for (int i = 1; i <= recs; i++)
            {
                var row = new AnswerGroup
                {
                    Name = "Answer Group " + Convert.ToString(i)
                };

                _answerGroup.Add(row);

                // add 5 options for each group ...
                int result = SeedAnswerOption(5, row);
                // add 5 questions for each group ...
                int res = SeedQuestion(5, row);
            }

            //verify result
            int count = _answerGroup.GetAll().Count();
            return count;
        }

        public int SeedAnswerOption(int recs, AnswerGroup _answerGroup)
        {
            // default: create 5 options for a group
            for (int i = 1; i <= recs; i++)
            {
                var row = new AnswerOption
                {
                    AnswerVal = i,
                    AnswerGroup = _answerGroup,
                    AnswerText = "Group " + Convert.ToString(_answerGroup.Id) + " Choice " + Convert.ToString(i)

                };

                _answerOption.Add(row);
            }

            //verify result
            int count = _answerOption.GetAll().Count();
            return count;
        }

        public int SeedQuestion(int recs, AnswerGroup _answerGroup)
        {
            // default: create 5 questions for a group ... = 5*5 for each survey
            for (int i = 1; i <= recs; i++)
            {
                var row = new Question
                {
                    QGroup = 1,  //default
                    Order = i,
                    QuestionText = "Question " + Convert.ToString(i),
                    AnswerGroup = _answerGroup

                };

                _question.Add(row);

                int result = SeedSurveyQuestion(10, row); //rc. 10 surveys * 25 questions each
            }

            //verify result
            int count = _question.GetAll().Count();
            return count;
        }

        public int SeedSurveyQuestion(int recs, Question _question)
        {
            // #recs here should equal the number of surveys created in step 1
            // Question will have same text but will have unique ID
            for (int i = 1; i <= recs; i++)
            {
                var survey = _surveyMaster.Get(i);
                var row = new SurveyQuestion
                {
                    Question = _question,
                    SurveyMaster = survey

                };

                _surveyQuestion.Add(row);
            }

            //verify result
            int count = _surveyQuestion.GetAll().Count();
            return count;
        }

        public int SeedResult()
        {
            // ** DEV NOTES ** Will encounter threading error if the ToList() method is not called in here
            // -- on the foreach loops. This loads data into memory ...
            // OR the SaveChanges() could be performed at the end of the cycle.

            // initialize objects
            var sessions = _sessionUser.GetAll().ToList();   // 1000 sessions for 10 surveys
                                                    //var surveys = _surveyMaster.GetAll();   // 10
                                                    //var questions = _question.GetAll();     // 25 questions/survey
                                                    //var answerOption = _answerOption.Get(0);
            Random rnd = new Random();

            //for (var x = 1; x <= sessions.Count(); x++)
            foreach(var s in sessions)
            {
                // get the session and survey
                var session = _sessionUser.Get(s.Id);
                var survey = _surveyMaster.Get(s.SurveyMaster.Id);

                // get all questions for (each) survey
                var questions = _surveyQuestion.GetAllBySurveyId(s.SurveyMaster.Id).ToList();
                foreach (var q in questions)
                {
                    // create a single question object             
                    var question = _question.Get(q.Question.Id);

                    // get a random answer 1-5
                    int option = rnd.Next(1, 5);
                    var answerOption = _answerOption.Get(option);

                    var newResult = new Result
                    {
                        Session = session,
                        SurveyMaster = survey,
                        Question = question,
                        AnswerOption = answerOption
                    };

                    _result.Add(newResult);
                }
            }
            return 1;
        }

        //protected string GetIPAddress()
        //{

        //    System.Web.HttpContext context = System.Web.HttpContext.Current;
        //    string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    if (!string.IsNullOrEmpty(ipAddress))
        //    {
        //        string[] addresses = ipAddress.Split(',');
        //        if (addresses.Length != 0)
        //        {
        //            return addresses[0];
        //        }
        //    }

        //    return context.Request.ServerVariables["REMOTE_ADDR"];
        //}
    }
}
