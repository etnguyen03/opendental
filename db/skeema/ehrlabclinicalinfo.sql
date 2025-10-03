CREATE TABLE `ehrlabclinicalinfo` (
  `EhrLabClinicalInfoNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabNum` bigint(20) NOT NULL,
  `ClinicalInfoID` varchar(255) NOT NULL,
  `ClinicalInfoText` varchar(255) NOT NULL,
  `ClinicalInfoCodeSystemName` varchar(255) NOT NULL,
  `ClinicalInfoIDAlt` varchar(255) NOT NULL,
  `ClinicalInfoTextAlt` varchar(255) NOT NULL,
  `ClinicalInfoCodeSystemNameAlt` varchar(255) NOT NULL,
  `ClinicalInfoTextOriginal` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrLabClinicalInfoNum`),
  KEY `EhrLabNum` (`EhrLabNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
