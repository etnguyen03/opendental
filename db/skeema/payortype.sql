CREATE TABLE `payortype` (
  `PayorTypeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateStart` date NOT NULL DEFAULT '0001-01-01',
  `SopCode` varchar(255) NOT NULL,
  `Note` text NOT NULL,
  PRIMARY KEY (`PayorTypeNum`),
  KEY `PatNum` (`PatNum`),
  KEY `SopCode` (`SopCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
