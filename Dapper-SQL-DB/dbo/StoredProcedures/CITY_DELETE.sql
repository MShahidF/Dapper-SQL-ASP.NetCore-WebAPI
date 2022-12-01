CREATE PROCEDURE [dbo].[CITY_DELETE]
	@CityId int
AS
BEGIN
	
	DELETE FROM dbo.City
	Where CityId = @CityId

END
