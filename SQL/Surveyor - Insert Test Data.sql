/* Surveyor Db Setup
	Create:
		- 3 surveys
		- 8 sessions (users)
		- 3 sets of answers ( 2- 4 answers )
		- 3 sets of questions ( 2 - 4 questions)
*/
USE [NewsMan]
GO
DECLARE @NOW DATETIME = GETDATE();
DECLARE @DEF DATETIME = '01/01/1900';
--1. SurveyMaster
delete from SurveyMaster
INSERT INTO SurveyMaster(Name, Purpose, DateOpen, DateClose, Active) VALUES
	('News Survey 1', 'This is the purpose of this news survey 1', @NOW, @DEF, 1),
	('Survey 2', 'This is the purpose of this survey', @NOW, @DEF, 1),
	('Survey 3', 'This is the purpose of this survey', @NOW, @DEF, 1)

--2. Session
delete from Session
INSERT INTO Session(DateEntered, Origin, SurveyMasterId) VALUES
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 1),
	(@NOW, 'IP', 2),
	(@NOW, 'IP', 3)

--3. AnswerGroup
delete from AnswerGroup
INSERT INTO AnswerGroup(Name) VALUES
	('not much, a bit, moderate, lot'),
	('yes, no, d/k'),
	('Bank 3')

--4. AnswerOption
delete from AnswerOption
INSERT INTO AnswerOption(AnswerVal, AnswerText, AnswerGroupId) VALUES
	(1, 'Not much at all', 1),
	(2, 'A little bit', 1),
	(3, 'A moderate amount', 1),
	(4, 'A lot', 1),
	(1, 'Yes', 2),
	(2, 'No', 2),
	(3, 'Dont know', 2),
	(1, 'True', 3),
	(2, 'False', 3)

--5. Question
delete from Question
INSERT INTO Question(QGroup, [Order], QuestionText, AnswerGroupId) VALUES
	(1, 1, 'How much news do you follow?', 1),
	(1, 2, 'How much of the news is truthful?', 1),
	(1, 3, 'How much of the news is positive?', 1),
	(1, 4, 'How important is the source of a news story to you?', 1),
	(2, 1, 'Does repeated exposure to a story make it more believable?', 2),
	(2, 2, 'Do you have a news source that you believe is the most truthful?', 2),
	(2, 3, 'Do you think the internet is the best way to get your news?', 2),
	(2, 4, 'Do you think the news sources from your own country of residence are more truthful than other countries?', 2),
	(3, 1, 'Not true', 3),
	(3, 2, 'Partly false', 3)

--6. QuestionSurvey
delete from SurveyQuestion
INSERT INTO SurveyQuestion(SurveyMasterId, QuestionId) VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6),
	(1, 7),
	(1, 8),
	(2, 9), 
	(2, 10),
	(3, 9),
	(3, 10)

--7. Result
--INSERT INTO Result(SessionId, SurveyId, QuestionId, AnswerOptionId) VALUES












