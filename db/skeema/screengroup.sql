CREATE TABLE `screengroup` (
  `ScreenGroupNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `SGDate` date NOT NULL DEFAULT '0000-00-00',
  `ProvName` varchar(255) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `PlaceService` tinyint(4) NOT NULL,
  `County` varchar(255) NOT NULL,
  `GradeSchool` varchar(255) NOT NULL,
  `SheetDefNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ScreenGroupNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `SheetDefNum` (`SheetDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
