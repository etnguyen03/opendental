CREATE TABLE `ehraptobs` (
  `EhrAptObsNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AptNum` bigint(20) NOT NULL,
  `IdentifyingCode` tinyint(4) NOT NULL,
  `ValType` tinyint(4) NOT NULL,
  `ValReported` varchar(255) NOT NULL,
  `UcumCode` varchar(255) NOT NULL,
  `ValCodeSystem` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrAptObsNum`),
  KEY `AptNum` (`AptNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
