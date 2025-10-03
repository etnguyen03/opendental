CREATE TABLE `reactivation` (
  `ReactivationNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ReactivationStatus` bigint(20) NOT NULL,
  `ReactivationNote` text NOT NULL,
  `DoNotContact` tinyint(4) NOT NULL,
  PRIMARY KEY (`ReactivationNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ReactivationStatus` (`ReactivationStatus`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
