CREATE TABLE `labturnaround` (
  `LabTurnaroundNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LaboratoryNum` bigint(20) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `DaysPublished` smallint(6) NOT NULL,
  `DaysActual` smallint(6) NOT NULL,
  PRIMARY KEY (`LabTurnaroundNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
