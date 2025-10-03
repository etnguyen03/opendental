CREATE TABLE `covcat` (
  `CovCatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(50) DEFAULT '',
  `DefaultPercent` smallint(6) NOT NULL,
  `CovOrder` int(11) NOT NULL,
  `IsHidden` tinyint(1) unsigned NOT NULL DEFAULT 0,
  `EbenefitCat` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`CovCatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
