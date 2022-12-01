CREATE PROCEDURE [dbo].[CITY_GET]
	@CityId int
AS
BEGIN
	
	SELECT 
		CityId, 
		CityName, 
		CityCode, 
		CountryId 
	FROM dbo.City
	Where CityId = @CityId

END
