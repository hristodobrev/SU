USE Blog

SELECT c.ID AS CommentID, c.Text, ISNULL(c.AuthorName, u.FullName) AS AuthorName

FROM Comments c LEFT JOIN Users u ON c.AuthorID = u.ID

WHERE PostID = 1