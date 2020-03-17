/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [LoginD]    Script Date: 03/03/2020 17:00:20 ******/
CREATE LOGIN [LoginD] WITH PASSWORD=N'ºTs÷ò«sFÞ-Lvù6#ZK>ß¡¡sS', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [LoginD] DISABLE
GO

