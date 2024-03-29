SELECT COUNT(*) AS PostsCount FROM Posts
WHERE AuthorId = 2

SELECT MIN(AuthorId) AS MinValue FROM Posts

SELECT MIN(Date) AS Oldest FROM Posts

SELECT MAX(AuthorId) AS MaxValue FROM Posts

SELECT MAX(ID) AS MaxValue FROM Tags

SELECT SUM(ID) AS SumIds FROM Tags

SELECT SUM(ID) AS SumUsersWithPosts FROM Users
WHERE ID IN(SELECT AuthorId FROM Posts)