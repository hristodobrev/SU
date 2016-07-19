USE Blog

INSERT INTO Posts(Title, Body, AuthorID)
VALUES ('New Post', 'Some text.', 5)

INSERT INTO Users(Username, PasswordHash) VALUES 
	('joe', HASHBYTES('SHA2_256', 'P@$$@123')),
	('jeff', HASHBYTES('SHA2_256', 'SofiA!')),
	('poly', HASHBYTES('SHA2_256', 'p@ss123'))