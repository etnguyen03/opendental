CREATE TABLE `question` (
  `QuestionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ItemOrder` smallint(5) unsigned NOT NULL,
  `Description` text DEFAULT NULL,
  `Answer` text DEFAULT NULL,
  `FormPatNum` bigint(20) NOT NULL,
  PRIMARY KEY (`QuestionNum`),
  KEY `indexPatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
