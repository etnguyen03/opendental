CREATE TABLE `loginattempt` (
  `LoginAttemptNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) NOT NULL,
  `LoginType` tinyint(4) NOT NULL,
  `DateTFail` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`LoginAttemptNum`),
  KEY `UserName` (`UserName`(10))
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
