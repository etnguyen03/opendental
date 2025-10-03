CREATE TABLE `treatplanparam` (
  `TreatPlanParamNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `TreatPlanNum` bigint(20) NOT NULL,
  `ShowDiscount` tinyint(4) NOT NULL,
  `ShowMaxDed` tinyint(4) NOT NULL,
  `ShowSubTotals` tinyint(4) NOT NULL,
  `ShowTotals` tinyint(4) NOT NULL,
  `ShowCompleted` tinyint(4) NOT NULL,
  `ShowFees` tinyint(4) NOT NULL,
  `ShowIns` tinyint(4) NOT NULL,
  PRIMARY KEY (`TreatPlanParamNum`),
  KEY `PatNum` (`PatNum`),
  KEY `TreatPlanNum` (`TreatPlanNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
