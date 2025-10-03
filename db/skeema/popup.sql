CREATE TABLE `popup` (
  `PopupNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `Description` text DEFAULT NULL,
  `IsDisabled` tinyint(1) NOT NULL,
  `PopupLevel` tinyint(4) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `DateTimeEntry` datetime NOT NULL,
  `IsArchived` tinyint(4) NOT NULL,
  `PopupNumArchive` bigint(20) NOT NULL,
  `DateTimeDisabled` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`PopupNum`),
  KEY `UserNum` (`UserNum`),
  KEY `PopupNumArchive` (`PopupNumArchive`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
