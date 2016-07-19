USE Blog

SELECT MIN(Date) FROM Comments

SELECT COUNT(*) FROM Comments
WHERE PostID = 1

SELECT PostID, COUNT(ID) AS CommentsCount
FROM Comments
GROUP BY PostID