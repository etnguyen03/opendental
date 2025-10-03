CREATE TABLE `language` (
  `LanguageNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EnglishComments` text DEFAULT NULL,
  `ClassType` text DEFAULT NULL,
  `English` text DEFAULT NULL,
  `IsObsolete` tinyint(1) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`LanguageNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
