CREATE TABLE `mobilebrandingprofile` (
  `MobileBrandingProfileNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `OfficeDescription` varchar(255) NOT NULL,
  `LogoFilePath` varchar(255) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`MobileBrandingProfileNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
