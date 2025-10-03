CREATE TABLE `discountplan` (
  `DiscountPlanNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `FeeSchedNum` bigint(20) NOT NULL,
  `DefNum` bigint(20) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `PlanNote` text NOT NULL,
  `ExamFreqLimit` int(11) NOT NULL,
  `XrayFreqLimit` int(11) NOT NULL,
  `ProphyFreqLimit` int(11) NOT NULL,
  `FluorideFreqLimit` int(11) NOT NULL,
  `PerioFreqLimit` int(11) NOT NULL,
  `LimitedExamFreqLimit` int(11) NOT NULL,
  `PAFreqLimit` int(11) NOT NULL,
  `AnnualMax` double NOT NULL DEFAULT -1,
  PRIMARY KEY (`DiscountPlanNum`),
  KEY `FeeSchedNum` (`FeeSchedNum`),
  KEY `DefNum` (`DefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
