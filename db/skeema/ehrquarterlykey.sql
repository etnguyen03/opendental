CREATE TABLE `ehrquarterlykey` (
  `EhrQuarterlyKeyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `YearValue` int(11) NOT NULL,
  `QuarterValue` int(11) NOT NULL,
  `PracticeName` varchar(255) NOT NULL,
  `KeyValue` varchar(255) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `Notes` text NOT NULL,
  PRIMARY KEY (`EhrQuarterlyKeyNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
