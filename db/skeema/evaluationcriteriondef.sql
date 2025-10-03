CREATE TABLE `evaluationcriteriondef` (
  `EvaluationCriterionDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EvaluationDefNum` bigint(20) NOT NULL,
  `CriterionDescript` varchar(255) NOT NULL,
  `IsCategoryName` tinyint(4) NOT NULL,
  `GradingScaleNum` bigint(20) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `MaxPointsPoss` float NOT NULL,
  PRIMARY KEY (`EvaluationCriterionDefNum`),
  KEY `EvaluationDefNum` (`EvaluationDefNum`),
  KEY `GradingScaleNum` (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
