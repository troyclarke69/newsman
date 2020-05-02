select 
	s.Id SessionId, sm.Id SurveyId, sm.Name,
	sq.QuestionId,
	q.QGroup, QuestionText,
	ag.Name,
	ao.AnswerVal, ao.AnswerText

from SurveyMaster  sm
left outer join Session s
	on s.SurveyMasterId = sm.Id		-- 6 people = survey 1, 1 person = survey 2, 1 person = survey 3 = 52 rows

left outer join SurveyQuestion sq
	on sm.Id = sq.SurveyMasterId		-- 6 people x 8 questions for survey 1. NO questions for survey 2&3
left outer join Question q
	on sq.QuestionId = q.Id		-- still 52 rows ...
left outer join AnswerGroup ag
	on q.AnswerGroupId = ag.Id	-- still 52 rows ...
left outer join AnswerOption ao
	on ag.Id = ao.AnswerGroupId -- (6 people * 4 questions * 4 answer(options)) + (6 people * 4 questions * 3 answer(options)) = 96 + 72 = 168 + survey 2 & 3 (8) = 176


