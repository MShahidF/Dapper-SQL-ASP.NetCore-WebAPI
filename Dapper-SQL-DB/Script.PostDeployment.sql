IF NOT EXISTS (SELECT 1 FROM dbo.Country)
BEGIN

	INSERT INTO dbo.Country (CountryId, CountryName, CountryCode)
	VALUES (1, 'Pakistan', 'PAK'),
	(2, 'Saudi Arabia', 'SAU');

	INSERT INTO dbo.City (CityId, CityName, CityCode, CountryId)
	VALUES (1, 'Karachi', 'KHI', 1),
	(2, 'Lahore', 'LHE', 1),
	(3, 'Islamabad', 'ISB', 1),
	(4, 'Jeddah', 'JED', 2),
	(5, 'Riyadh', 'RUH', 2),
	(6, 'Dammam', 'DMM', 2);
	
END

