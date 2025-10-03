CREATE TABLE `lettermerge` (
  `LetterMergeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `TemplateName` varchar(255) DEFAULT '',
  `DataFileName` varchar(255) DEFAULT '',
  `Category` bigint(20) NOT NULL,
  `ImageFolder` bigint(20) NOT NULL,
  PRIMARY KEY (`LetterMergeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
