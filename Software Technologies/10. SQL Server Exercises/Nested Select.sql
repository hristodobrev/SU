USE Blog

SELECT DISTINCT p.ID AS PostID, p.Title AS PostTitle
FROM Posts p JOIN Posts_Tags pt ON pt.PostID = p.ID
WHERE p.ID IN (SELECT PostID FROM Tags WHERE Name IN ('Programming', 'Web'))