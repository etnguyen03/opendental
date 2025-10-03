CREATE TABLE `evaluationcriterion` (
  `EvaluationCriterionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EvaluationNum` bigint(20) NOT NULL,
  `CriterionDescript` varchar(255) NOT NULL,
  `IsCategoryName` tinyint(4) NOT NULL,
  `GradingScaleNum` bigint(20) NOT NULL,
  `GradeShowing` varchar(255) NOT NULL,
  `GradeNumber` float NOT NULL,
  `Notes` text NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `MaxPointsPoss` float NOT NULL,
  PRIMARY KEY (`EvaluationCriterionNum`),
  KEY `EvaluationNum` (`EvaluationNum`),
  KEY `GradingScaleNum` (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
