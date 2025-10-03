CREATE TABLE `ehrprovkey` (
  `EhrProvKeyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `LName` varchar(255) NOT NULL,
  `FName` varchar(255) NOT NULL,
  `ProvKey` varchar(255) NOT NULL,
  `FullTimeEquiv` float NOT NULL,
  `Notes` text NOT NULL,
  `YearValue` int(11) NOT NULL,
  PRIMARY KEY (`EhrProvKeyNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
