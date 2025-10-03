CREATE TABLE `county` (
  `CountyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CountyName` varchar(255) NOT NULL DEFAULT '',
  `CountyCode` varchar(255) DEFAULT '',
  PRIMARY KEY (`CountyNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
