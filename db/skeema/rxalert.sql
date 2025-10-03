CREATE TABLE `rxalert` (
  `RxAlertNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RxDefNum` bigint(20) NOT NULL,
  `DiseaseDefNum` bigint(20) NOT NULL,
  `AllergyDefNum` bigint(20) NOT NULL,
  `MedicationNum` bigint(20) NOT NULL,
  `NotificationMsg` varchar(255) NOT NULL,
  `IsHighSignificance` tinyint(4) NOT NULL,
  PRIMARY KEY (`RxAlertNum`),
  KEY `AllergyDefNum` (`AllergyDefNum`),
  KEY `MedicationNum` (`MedicationNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
