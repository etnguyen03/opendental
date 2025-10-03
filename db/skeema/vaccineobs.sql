CREATE TABLE `vaccineobs` (
  `VaccineObsNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `VaccinePatNum` bigint(20) NOT NULL,
  `ValType` tinyint(4) NOT NULL,
  `IdentifyingCode` tinyint(4) NOT NULL,
  `ValReported` varchar(255) NOT NULL,
  `ValCodeSystem` tinyint(4) NOT NULL,
  `VaccineObsNumGroup` bigint(20) NOT NULL,
  `UcumCode` varchar(255) NOT NULL,
  `DateObs` date NOT NULL DEFAULT '0001-01-01',
  `MethodCode` varchar(255) NOT NULL,
  PRIMARY KEY (`VaccineObsNum`),
  KEY `VaccinePatNum` (`VaccinePatNum`),
  KEY `VaccineObsNumGroup` (`VaccineObsNumGroup`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
