CREATE TABLE `proccodenote` (
  `ProcCodeNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CodeNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `Note` text DEFAULT NULL,
  `ProcTime` varchar(255) DEFAULT NULL,
  `ProcStatus` tinyint(4) NOT NULL,
  PRIMARY KEY (`ProcCodeNoteNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
