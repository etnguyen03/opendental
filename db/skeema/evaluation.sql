CREATE TABLE `evaluation` (
  `EvaluationNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `InstructNum` bigint(20) NOT NULL,
  `StudentNum` bigint(20) NOT NULL,
  `SchoolCourseNum` bigint(20) NOT NULL,
  `EvalTitle` varchar(255) NOT NULL,
  `DateEval` date NOT NULL DEFAULT '0001-01-01',
  `GradingScaleNum` bigint(20) NOT NULL,
  `OverallGradeShowing` varchar(255) NOT NULL,
  `OverallGradeNumber` float NOT NULL,
  `Notes` text NOT NULL,
  PRIMARY KEY (`EvaluationNum`),
  KEY `InstructNum` (`InstructNum`),
  KEY `StudentNum` (`StudentNum`),
  KEY `SchoolCourseNum` (`SchoolCourseNum`),
  KEY `GradingScaleNum` (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
