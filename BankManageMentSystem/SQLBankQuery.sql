CREATE TABLE Users(
	User_id int PRIMARY KEY IDENTITY,
	FirstName varchar(30) NOT NULL
);

CREATE TABLE Logins(
	Login_id int PRIMARY KEY IDENTITY,
	User_id int FOREIGN KEY REFERENCES Users(User_id),
	Username varchar(30) UNIQUE NOT NULL,
	Password varchar(30) NOT NULL,
	IsAdmin bit NOT NULL
);

INSERT INTO Users VALUES('Emil');
INSERT INTO Logins VALUES(1, 'admin', 'password', 1);