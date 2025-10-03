CREATE TABLE `site` (
  `SiteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `Note` text DEFAULT NULL,
  `Address` varchar(100) NOT NULL,
  `Address2` varchar(100) NOT NULL,
  `City` varchar(100) NOT NULL,
  `State` varchar(100) NOT NULL,
  `Zip` varchar(100) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `PlaceService` tinyint(4) NOT NULL,
  PRIMARY KEY (`SiteNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
