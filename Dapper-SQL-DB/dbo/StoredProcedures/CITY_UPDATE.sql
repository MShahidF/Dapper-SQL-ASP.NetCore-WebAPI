CREATE PROCEDURE [dbo].[CITY_UPDATE]
	@CityId int,
	@CityName nvarchar(50),
	@CityCode nvarchar(5),
	@CountryId int
AS
BEGIN

	UPDATE City
	SET CityName = @CityName,
	CityCode = @CityCode,
	CountryId = @CountryId
	WHERE CityId = @CityId

END
