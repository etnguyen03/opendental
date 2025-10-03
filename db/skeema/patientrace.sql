CREATE TABLE `patientrace` (
  `PatientRaceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `Race` tinyint(4) NOT NULL,
  `CdcrecCode` varchar(255) NOT NULL,
  PRIMARY KEY (`PatientRaceNum`),
  KEY `PatNum` (`PatNum`),
  KEY `CdcrecCode` (`CdcrecCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
