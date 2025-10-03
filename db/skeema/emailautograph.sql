CREATE TABLE `emailautograph` (
  `EmailAutographNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` text NOT NULL,
  `EmailAddress` varchar(255) NOT NULL,
  `AutographText` text NOT NULL,
  PRIMARY KEY (`EmailAutographNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
