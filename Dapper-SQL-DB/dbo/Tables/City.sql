CREATE TABLE [dbo].[City]
(
	[CityId] INT NOT NULL PRIMARY KEY, 
    [CityName] NVARCHAR(50) NOT NULL, 
    [CityCode] NVARCHAR(5) NULL, 
    [CountryId] INT NOT NULL 
)
