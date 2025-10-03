CREATE TABLE `recalltype` (
  `RecallTypeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `DefaultInterval` int(11) NOT NULL,
  `TimePattern` varchar(255) DEFAULT NULL,
  `Procedures` varchar(255) DEFAULT NULL,
  `AppendToSpecial` tinyint(4) NOT NULL,
  PRIMARY KEY (`RecallTypeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
