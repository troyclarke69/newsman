using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface ISeedService
    {
        int SeedSurveyMaster(int recs);
        int SeedSessionUser(int recs, SurveyMaster _surveyMaster);
        int SeedAnswerGroup(int recs);
        int SeedAnswerOption(int recs, AnswerGroup _answerGroup);
        int SeedQuestion(int recs, AnswerGroup _answerGroup);
        int SeedSurveyQuestion(int recs, Question _question);
        int SeedResult();
    }
}
