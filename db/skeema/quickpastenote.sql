CREATE TABLE `quickpastenote` (
  `QuickPasteNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `QuickPasteCatNum` bigint(20) NOT NULL,
  `ItemOrder` smallint(5) unsigned NOT NULL DEFAULT 0,
  `Note` text DEFAULT NULL,
  `Abbreviation` varchar(255) DEFAULT '',
  PRIMARY KEY (`QuickPasteNoteNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
