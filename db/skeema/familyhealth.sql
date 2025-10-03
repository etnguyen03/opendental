CREATE TABLE `familyhealth` (
  `FamilyHealthNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `Relationship` tinyint(4) NOT NULL,
  `DiseaseDefNum` bigint(20) NOT NULL,
  `PersonName` varchar(255) NOT NULL,
  PRIMARY KEY (`FamilyHealthNum`),
  KEY `PatNum` (`PatNum`),
  KEY `DiseaseDefNum` (`DiseaseDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
