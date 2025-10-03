CREATE TABLE `sessiontoken` (
  `SessionTokenNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SessionTokenHash` varchar(255) NOT NULL,
  `Expiration` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `TokenType` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  PRIMARY KEY (`SessionTokenNum`),
  KEY `FKey` (`FKey`),
  KEY `SessionTokenHash` (`SessionTokenHash`(20)),
  KEY `Expiration` (`Expiration`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
