CREATE TABLE [dbo].[CardAttributes]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DeckId] int not null foreign key references DeckSelection(id),
	attrname1 varchar(255) not null,
	attrname2 varchar(255) not null,
	attrname3 varchar(255) not null,
	attrname4 varchar(255) not null,
	attrname5 varchar(255) not null
)