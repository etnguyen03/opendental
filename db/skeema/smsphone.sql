CREATE TABLE `smsphone` (
  `SmsPhoneNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `PhoneNumber` varchar(255) NOT NULL,
  `DateTimeActive` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTimeInactive` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `InactiveCode` varchar(255) NOT NULL,
  `CountryCode` varchar(255) NOT NULL,
  PRIMARY KEY (`SmsPhoneNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
