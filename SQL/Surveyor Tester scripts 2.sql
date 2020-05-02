-- TEST: each @surveyMasterId has 100 sessions/rows ... ie. @SessionId = 11 -> @SurveyMasterId = 2
DECLARE @SessionId int = 101;
DECLARE @SurveyMasterId int;
select @SurveyMasterId = SurveyMasterId from Session where Id = @SessionId
--
--select * from Session where Id = @SessionId
--
--select * from SurveyMaster where Id = @SurveyMasterId
-- 
--select * from SurveyQuestion where SurveyMasterId = @SurveyMasterId

-- 100 sessions
select * from Session where SurveyMasterId = @SurveyMasterId;

-- 25 (5 answer groups * 5 questions/group) *** ie. there are 25 QUESTIONS PER SURVEY
select * from SurveyQuestion sq inner join SurveyMaster sm on sq.SurveyMasterId = sm.Id
	inner join Question q on sq.QuestionId = q.Id
where SurveyMasterId = @SurveyMasterId

-- 125 (25 questions * 5 options/ea)
select * from SurveyQuestion sq 
	inner join SurveyMaster sm on sq.SurveyMasterId = sm.Id
	inner join Question q on sq.QuestionId = q.Id
	inner join AnswerGroup ag on q.AnswerGroupId = ag.Id
	inner join AnswerOption ao on ao.AnswerGroupId = ag.Id
where sq.SurveyMasterId = @SurveyMasterId

select * from Result where SurveyMasterId =1
--AnswerOptionId in (1)
--delete from Result
select * from SurveyQuestion where SurveyMasterId = 1

select QuestionId, AnswerOptionId, count(*) [Count] ,
	(cast(count(*) as money) / 100) * 100 [Perc]
from Result 
where SurveyMasterId = 1
group by QuestionId, AnswerOptionId
order by QuestionId, AnswerOptionId