CREATE TABLE [dbo].[Cards]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DeckId] int not null foreign key references (DeckSelection),
	[Name] VARCHAR(255) Not null,
	Attr1 int Not null,
	Attr2 int Not null,
	Attr3 int not null,
	Attr4 int not null,
	Attr5 int not null,
	Flavourtext varchar(8000),
	Imagepath varchar(511) not null
)