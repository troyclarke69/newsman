using Microsoft.AspNetCore.Mvc;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using NewsMan.Service.Services;
using NewsMan.ViewModels;
using System;
using System.Linq;

namespace NewsMan.Controllers
{
    public class TestsController : Controller
    {
        private readonly IQMaster _questions;
        private readonly ISurvey _answers;
        private readonly IAMaster _answerOptions;

        //Part 2 vars...
        private readonly IResult _results;
        private readonly ISeedService _seedService;
        private readonly IQuestion _demoQuestions;
        private readonly ISurveyMaster _demoSurveys;
        private readonly ISessionUser _demoSessionUsers;
        private readonly IAnswerOption _demoAnswerOptions;
        

        public TestsController(IQMaster question, ISurvey survey, IAMaster answerOptions, IResult results,
                    ISeedService seedService, IQuestion demoQuestions, ISurveyMaster demoSurveyMasters,
                        ISessionUser demoSessionUsers, IAnswerOption demoAnswerOptions)
        {
            _questions = question;
            _answers = survey;
            _answerOptions = answerOptions;
            _results = results;
            _seedService = seedService;
            _demoQuestions = demoQuestions;
            _demoAnswerOptions = demoAnswerOptions;
            _demoSessionUsers = demoSessionUsers;
            _demoSurveys = demoSurveyMasters;
        }

        public IActionResult InsertDataP1(TestListingModel tmodel)
        {
            if (tmodel.Answers != null)
            {
                // -d HACK: delete the pre-loaded entries for this sessionId. ANSWER == 0
                _answers.DeleteAllBySessionId(TempData["SessionId"].ToString());

                //add to Survey table
                for (int i = 1; i <= tmodel.Answers.Count(); i++)
                {
                    var question = _questions.Get(tmodel.Answers[i - 1].QMaster.Id);

                    var newSurvey = new Survey
                    {
                        SessionId = TempData["SessionId"].ToString(),
                        QMaster = question,
                        Answer = tmodel.Answers[i - 1].Answer
                    };
                    _answers.Add(newSurvey);
                }
            }

            TempData.Keep();
            return RedirectToAction("Index3", "Tests");
        }

        public IActionResult InsertDataP3(TestListingModel tmodel)
        {
            if (tmodel.Answers != null)
            {
                // -d HACK: delete the pre-loaded entries for this sessionId. ANSWER == 0
                _answers.DeleteAllBySessionId(TempData["SessionId"].ToString());

                //add to Survey table
                for (int i = 1; i <= tmodel.Answers.Count(); i++)
                {
                    var question = _questions.Get(tmodel.Answers[i - 1].QMaster.Id);

                    var newSurvey = new Survey
                    {
                        SessionId = TempData["SessionId"].ToString(),
                        QMaster = question,
                        Answer = tmodel.Answers[i - 1].Answer
                    };
                    _answers.Add(newSurvey);
                }
            }

            TempData.Keep();
            return RedirectToAction("Index4", "Tests");
        }

        public IActionResult Index()
        {

            // seed 'Results' db if no data exists
            //var result1 = _seedService.SeedSurveyMaster(10); //craate 10 surveys
            //var result2 = _seedService.SeedAnswerGroup(5); //create 5 groups of answers ... each containing x options
            //var result3 = _seedService.SeedResult();

            var sessionId = string.Empty;
            if (TempData["SessionId"] == null)
            {
                sessionId = Guid.NewGuid().ToString();

                // store the session ID in TempData
                TempData["SessionId"] = sessionId;
            }

            var questionModel = _questions.GetAllByLevel(1);
            var q = questionModel.Select(q => new QuestionListingModel
            {
                Id = q.Id,
                Level = q.Level,
                Order = q.Order,
                Question = q.Question

            }).ToList();

            // THIS IS A HACK ??
            // pre-load the survey (answer) model... 
            foreach (var row in q)
            {
                var question = _questions.Get(row.Id);
                var newRow = new Survey
                {
                    SessionId = sessionId,
                    QMaster = question,
                    Answer = 0
                };
                _answers.Add(newRow);
            }

            // load model for UI ... this was just populated above
            var answerModel = _answers.GetAllBySessionId(sessionId);
            var a = answerModel.Select(a => new SurveyListingModel
            {
                Id = a.Id,
                SessionId = a.SessionId,
                QMaster = a.QMaster,
                Answer = a.Answer

            }).ToList();

            var answerOptions = _answerOptions.GetAllByKey(1);
            var ao = answerOptions.Select(a => new AnswerListingModel
            {
                Id = a.Id,
                Key = a.Key,
                Val = a.Val,
                Answer = a.Answer

            }).ToList();

            var model = new TestListingModel
            {
                Questions = q,
                Answers = a,
                AnswerOptions = ao
            };

            TempData.Keep();
            return View(model);
        }

        public IActionResult Index3()
        {
            var sessionId = TempData["SessionId"].ToString();

            var questionModel = _questions.GetAllByLevel(2);
            var q = questionModel.Select(q => new QuestionListingModel
            {
                Id = q.Id,
                Level = q.Level,
                Order = q.Order,
                Question = q.Question

            }).ToList();

            // THIS IS A HACK ??
            // pre-load the survey (answer) model... 
            foreach (var row in q)
            {
                var question = _questions.Get(row.Id);
                var newRow = new Survey
                {
                    SessionId = sessionId,
                    QMaster = question,
                    Answer = 0
                };
                _answers.Add(newRow);
            }

            // load model for UI ... this was just populated above
            var answerModel = _answers.GetAllBySessionId(sessionId);
            var a = answerModel.Select(a => new SurveyListingModel
            {
                Id = a.Id,
                SessionId = a.SessionId,
                QMaster = a.QMaster,
                Answer = a.Answer

            }).ToList();

            var answerOptions = _answerOptions.GetAllByKey(4);
            var ao = answerOptions.Select(a => new AnswerListingModel
            {
                Id = a.Id,
                Key = a.Key,
                Val = a.Val,
                Answer = a.Answer

            }).ToList();

            var model = new TestListingModel
            {
                Questions = q,
                Answers = a,
                AnswerOptions = ao
            };

            TempData.Keep();
            return View(model);
        }

        public IActionResult Index4()
        {

            var sessionId = TempData["SessionId"].ToString();

            var questionModel = _questions.GetAllByLevel(0);
            var q = questionModel.Select(q => new QuestionListingModel
            {
                Id = q.Id,
                Level = q.Level,
                Order = q.Order,
                Question = q.Question

            }).ToList();

            // load model for UI ... ALL ANSWERED questions
            var answerModel = _answers.GetAllBySurvey(sessionId);
            var a = answerModel.Select(a => new SurveyListingModel
            {
                Id = a.Id,
                SessionId = a.SessionId,
                QMaster = a.QMaster,
                Answer = a.Answer,
                AnswerText = _answerOptions.GetAnswerText(a.QMaster.Key, a.Answer),
                Votes = _answers.GetTotalVotes(a.QMaster.Id, a.QMaster.Key),
                Percentage = _answers.GetAnswerPercentage(_answers.GetTotalVotes(a.QMaster.Id, a.QMaster.Key),
                                _answers.GetTotalSessions())

            }).ToList();


            // first, get all questions/answers based on the current session
            //var surveySummary = _answers.GetAllBySurvey(sessionId);

            //var answerSummary = _answers.GetAllSurveyResults(sessionId);
            //// second, load up the SurveyAnswerListingModel ... loop through each question/answer combo and return stats
            //var a_s = answerSummary.Select(a => new SurveyAnswerListingModel
            //{
            //    Id = a.Id,
            //    Key = a.QMaster.Key,
            //    Val = a.AMaster.Val,
            //    AnswerText = _answerOptions.GetAnswerText(a.QMaster.Key, a.AMaster.Val),
            //    Votes = _answers.GetTotalVotes(a.QMaster.Id, a.QMaster.Key),
            //    Percentage = _answers.GetAnswerPercentage(_answers.GetTotalVotes(a.QMaster.Id, a.QMaster.Key),
            //                    _answers.GetTotalSessions())

            //}).ToList();

            //// third, compile data ... 
            //var s = surveySummary.Select(a => new SurveySummaryModel
            //{
            //    QuestionId = a.QMaster.Id,
            //    AnswerKey = a.QMaster.Key,
            //    SessionAnswer = a.Answer,
            //    AnswerText = _answerOptions.GetAnswerText(a.QMaster.Key, a.Answer),
            //    AnswerStats = a_s
            //}).ToList();

            var model = new ResultListingModel
            {
                TotalSessions = _answers.GetTotalSessions(),
                Answers = a
                //Summary = s
            };

            TempData.Keep();
            return View(model);
        }

        public IActionResult Index5()
        {
            var sessionId = TempData["SessionId"].ToString();

            // load model for UI ... ALL ANSWERED questions
            //var answerModel = _answers.GetAllBySurvey(sessionId);
            var answerModel = _results.GetAllBySurvey(1);
            var a = answerModel.Select(a => new ResultPart2ListingModel
            {
                Id = a.Id,
                Question = a.Question,
                Survey = a.SurveyMaster,
                Answer = a.AnswerOption.AnswerVal,
                AnswerText = a.AnswerOption.AnswerText,
                Votes = _results.GetTotalVotes(a.Question.Id, a.AnswerOption.Id),
                Percentage = _answers.GetAnswerPercentage(_results.GetTotalVotes(a.Question.Id, a.AnswerOption.Id),
                                _results.GetTotalSessions(1))

            }).ToList();

            var model = new ResultSummaryListingModel
            {
                TotalSessions = _results.GetTotalSessions(1),
                Results = a
                //Summary = s
            };

            TempData.Keep();
            return View(model);
        }
    }
}