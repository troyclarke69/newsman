using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using NewsMan.ViewModels;

namespace NewsMan.Controllers
{
    public class TestsController : Controller
    {
        private readonly IQMaster _questions;
        private readonly ISurvey _answers;
        private readonly IAMaster _answerOptions;

        public TestsController(IQMaster question, ISurvey survey, IAMaster answerOptions)
        {
            _questions = question;
            _answers = survey;
            _answerOptions = answerOptions;
        }

        public IActionResult InsertDataP1(TestListingModel tmodel)
        {
            // -d Testing only ... this should be called from a pre-process for page 2 of the test (?) ...
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

                // onto next page: /views/Tests/...
                //tmodel.Answers = null;
                //return View();
            }

            TempData.Keep();
            return RedirectToAction("Index3", "Tests");
        }

        public IActionResult InsertDataP3(TestListingModel tmodel)
        {
            // -d Testing only ... this should be called from a pre-process for page 2 of the test (?) ...
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

                // onto next page: /views/Tests/...
                //tmodel.Answers = null;
                //return View();
            }

            TempData.Keep();
            return RedirectToAction("Index4", "Tests");
        }

        public IActionResult Index()
        {
            
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

            //var sessionId = string.Empty;
            //if (TempData["SessionId"] == null)
            //{
            //    sessionId = Guid.NewGuid().ToString();

            //    // store the session ID in TempData
            //    TempData["SessionId"] = sessionId;
            //}
            //TempData.Keep();

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

            //var sessionId = string.Empty;
            //if (TempData["SessionId"] == null)
            //{
            //    sessionId = Guid.NewGuid().ToString();

            //    // store the session ID in TempData
            //    TempData["SessionId"] = sessionId;
            //}
            //TempData.Keep();

            var sessionId = TempData["SessionId"].ToString();



            var questionModel = _questions.GetAllByLevel(0);
            var q = questionModel.Select(q => new QuestionListingModel
            {
                Id = q.Id,
                Level = q.Level,
                Order = q.Order,
                Question = q.Question

            }).ToList();

            // THIS IS A HACK ?? ... Not needed for this page
            // pre-load the survey (answer) model... 
            //foreach (var row in q)
            //{
            //    var question = _questions.Get(row.Id);
            //    var newRow = new Survey
            //    {
            //        SessionId = sessionId,
            //        QMaster = question,
            //        Answer = 0
            //    };
            //    _answers.Add(newRow);
            //}

            // load model for UI ... ALL ANSWERED questions
            var answerModel = _answers.GetAllBySurvey(sessionId);
            var a = answerModel.Select(a => new SurveyListingModel
            {
                Id = a.Id,
                SessionId = a.SessionId,
                QMaster = a.QMaster,
                Answer = a.Answer,
                AnswerText = _answerOptions.GetAnswerText(a.QMaster.Key, a.Answer)

            }).ToList();

            // This is not needed but leaving it in ...
            //var answerOptions = _answerOptions.GetAllByKey(4);
            //var ao = answerOptions.Select(a => new AnswerListingModel
            //{
            //    Id = a.Id,
            //    Key = a.Key,
            //    Val = a.Val,
            //    Answer = a.Answer

            //}).ToList();

            var model = new ResultListingModel
            {
                Answers = a
          
            };

            TempData.Keep();
            return View(model);
        }
    }
}