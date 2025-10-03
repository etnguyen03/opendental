CREATE TABLE `userquery` (
  `QueryNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `FileName` varchar(255) DEFAULT '',
  `QueryText` mediumtext NOT NULL,
  `IsReleased` tinyint(4) DEFAULT 0,
  `IsPromptSetup` tinyint(4) NOT NULL DEFAULT 1,
  `DefaultFormatRaw` tinyint(4) NOT NULL,
  PRIMARY KEY (`QueryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
