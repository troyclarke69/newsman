SELECT TOP 10 [Id]    ,[SessionId]     ,[QMasterId]     ,[Answer]  FROM [NewsMan].[dbo].[Survey]
  --WHERE Answer = 5
  order by Id desc
 -- delete  FROM [NewsMan].[dbo].[Survey]  WHERE Id > 2938
		--WHERE Answer = 0
-- surveyor count
select count(distinct(sessionId)) from Survey where Answer != 0
-- average scores ex.
--select avg(Answer) from Survey where QMasterId = 1 and SessionId != '8174cc3f-624d-4340-a015-acffc7969f1f'

-- percentages
select QMasterId, Answer, count(*) [Count] ,
	(cast(count(*) as money) / 116) * 100 [Perc]
from Survey 
where Answer != 0
group by QMasterId, Answer
order by QMasterId, Answer