CREATE TABLE `questiondef` (
  `QuestionDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` text DEFAULT NULL,
  `ItemOrder` smallint(5) unsigned NOT NULL,
  `QuestType` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`QuestionDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
