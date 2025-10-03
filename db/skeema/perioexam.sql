CREATE TABLE `perioexam` (
  `PerioExamNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ExamDate` date NOT NULL DEFAULT '0000-00-00',
  `ProvNum` bigint(20) NOT NULL,
  `DateTMeasureEdit` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Note` text NOT NULL,
  PRIMARY KEY (`PerioExamNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
