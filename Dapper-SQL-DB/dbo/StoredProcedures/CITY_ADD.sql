CREATE PROCEDURE [dbo].[CITY_ADD]
	@CityId int,
	@CityName nvarchar(50),
	@CityCode nvarchar(5),
	@CountryId int
AS
BEGIN

	INSERT INTO City(CityId, CityName, CityCode, CountryId) VALUES (@CityId, @CityName, @CityCode, @CountryId)

END