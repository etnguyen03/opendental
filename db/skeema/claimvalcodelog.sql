CREATE TABLE `claimvalcodelog` (
  `ClaimValCodeLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimNum` bigint(20) NOT NULL,
  `ClaimField` varchar(5) NOT NULL,
  `ValCode` char(2) NOT NULL,
  `ValAmount` double NOT NULL,
  `Ordinal` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ClaimValCodeLogNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
