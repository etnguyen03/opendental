CREATE TABLE `formpat` (
  `FormPatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `FormDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`FormPatNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
