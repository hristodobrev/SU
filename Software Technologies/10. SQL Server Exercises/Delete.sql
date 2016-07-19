USE Blog

DELETE FROM Posts
WHERE ID = 1009

DELETE FROM Comments
WHERE AuthorID = (SELECT ID FROM Users Where Username = 'tanq')