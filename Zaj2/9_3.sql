/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [LoginC]    Script Date: 03/03/2020 17:00:14 ******/
CREATE LOGIN [LoginC] WITH PASSWORD=N'KüÝåÙ¦uUGY
CVl1\ðÅ¸wF=WG', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [LoginC] DISABLE
GO

