CREATE TABLE `inseditpatlog` (
  `InsEditPatLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FKey` bigint(20) NOT NULL,
  `LogType` tinyint(4) NOT NULL,
  `FieldName` varchar(255) NOT NULL,
  `OldValue` varchar(255) NOT NULL,
  `NewValue` varchar(255) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `ParentKey` bigint(20) NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`InsEditPatLogNum`),
  KEY `FkLogType` (`FKey`,`LogType`),
  KEY `UserNum` (`UserNum`),
  KEY `ParentKey` (`ParentKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
