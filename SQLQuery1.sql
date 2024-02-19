SELECT TOP (1000) [Id]
      ,[Name]
      ,[FirstName]
      ,[LastName]
      ,[Place]
  FROM [SuperHeroDb].[dbo].[SuperHeroes]


INSERT INTO dbo.SuperHeroes(Name, FirstName, LastName, Place)
VALUES ('Spiderman', 'Peter', 'Parker', 'New York City');

INSERT INTO dbo.SuperHeroes(Name, FirstName, LastName, Place)
VALUES ('Ironman', 'Tony', 'Stark', 'Malibu');

SELECT * from dbo.SuperHeroes;

DELETE FROM dbo.SuperHeroes where Id > 2;

DBCC CHECKIDENT ('dbo.SuperHeroes', RESEED, 2);
