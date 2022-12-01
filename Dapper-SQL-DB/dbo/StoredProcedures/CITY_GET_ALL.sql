CREATE PROCEDURE [dbo].[CITY_GET_ALL]
AS
BEGIN
	
	SELECT 
		CityId, 
		CityName, 
		CityCode, 
		CountryId 
	FROM dbo.City

END
