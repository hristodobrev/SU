USE Blog

SELECT p.ID AS PostID, p.Title, c.Id AS CommentID, c.Text, c.Date

FROM Posts p JOIN Comments c ON c.PostID = p.ID