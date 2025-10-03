CREATE TABLE `treatplanattach` (
  `TreatPlanAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TreatPlanNum` bigint(20) NOT NULL,
  `ProcNum` bigint(20) NOT NULL,
  `Priority` bigint(20) NOT NULL,
  PRIMARY KEY (`TreatPlanAttachNum`),
  KEY `TreatPlanNum` (`TreatPlanNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `Priority` (`Priority`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
