CREATE TABLE `procnote` (
  `ProcNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ProcNum` bigint(20) NOT NULL,
  `EntryDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `UserNum` bigint(20) NOT NULL,
  `Note` text DEFAULT NULL,
  `SigIsTopaz` tinyint(3) unsigned NOT NULL,
  `Signature` text DEFAULT NULL,
  PRIMARY KEY (`ProcNoteNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
