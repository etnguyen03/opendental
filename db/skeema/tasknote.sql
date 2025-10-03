CREATE TABLE `tasknote` (
  `TaskNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TaskNum` bigint(20) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `DateTimeNote` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Note` text NOT NULL,
  PRIMARY KEY (`TaskNoteNum`),
  KEY `TaskNum` (`TaskNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
