CREATE TABLE `apptviewitem` (
  `ApptViewItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ApptViewNum` bigint(20) NOT NULL,
  `OpNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `ElementDesc` varchar(255) DEFAULT '',
  `ElementOrder` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `ElementColor` int(11) NOT NULL DEFAULT 0,
  `ElementAlignment` tinyint(4) NOT NULL,
  `ApptFieldDefNum` bigint(20) NOT NULL,
  `PatFieldDefNum` bigint(20) NOT NULL,
  `IsMobile` tinyint(4) NOT NULL,
  PRIMARY KEY (`ApptViewItemNum`),
  KEY `OpNum` (`OpNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
