USE Blog

SELECT p.ID AS PostID, p.Title AS PostTitle, t.ID AS TagID, t.Name AS TagName

FROM Posts p JOIN Posts_Tags pt ON pt.PostID = p.ID JOIN Tags t ON pt.TagID = t.ID