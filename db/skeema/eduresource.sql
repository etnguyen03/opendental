CREATE TABLE `eduresource` (
  `EduResourceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DiseaseDefNum` bigint(20) NOT NULL,
  `MedicationNum` bigint(20) NOT NULL,
  `LabResultID` varchar(255) NOT NULL,
  `LabResultName` varchar(255) NOT NULL,
  `LabResultCompare` varchar(255) NOT NULL,
  `ResourceUrl` varchar(255) NOT NULL,
  `SmokingSnoMed` varchar(255) NOT NULL,
  PRIMARY KEY (`EduResourceNum`),
  KEY `DiseaseDefNum` (`DiseaseDefNum`),
  KEY `MedicationNum` (`MedicationNum`),
  KEY `LabResultID` (`LabResultID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
