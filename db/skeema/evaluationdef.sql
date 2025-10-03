CREATE TABLE `evaluationdef` (
  `EvaluationDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SchoolCourseNum` bigint(20) NOT NULL,
  `EvalTitle` varchar(255) NOT NULL,
  `GradingScaleNum` bigint(20) NOT NULL,
  PRIMARY KEY (`EvaluationDefNum`),
  KEY `SchoolCourseNum` (`SchoolCourseNum`),
  KEY `GradingScaleNum` (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
