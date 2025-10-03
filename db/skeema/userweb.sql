CREATE TABLE `userweb` (
  `UserWebNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FKey` bigint(20) NOT NULL,
  `FKeyType` tinyint(4) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `PasswordResetCode` varchar(255) NOT NULL,
  `RequireUserNameChange` tinyint(4) NOT NULL,
  `DateTimeLastLogin` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `RequirePasswordChange` tinyint(4) NOT NULL,
  PRIMARY KEY (`UserWebNum`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
