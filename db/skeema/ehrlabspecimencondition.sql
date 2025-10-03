CREATE TABLE `ehrlabspecimencondition` (
  `EhrLabSpecimenConditionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabSpecimenNum` bigint(20) NOT NULL,
  `SpecimenConditionID` varchar(255) NOT NULL,
  `SpecimenConditionText` varchar(255) NOT NULL,
  `SpecimenConditionCodeSystemName` varchar(255) NOT NULL,
  `SpecimenConditionIDAlt` varchar(255) NOT NULL,
  `SpecimenConditionTextAlt` varchar(255) NOT NULL,
  `SpecimenConditionCodeSystemNameAlt` varchar(255) NOT NULL,
  `SpecimenConditionTextOriginal` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrLabSpecimenConditionNum`),
  KEY `EhrLabSpecimenNum` (`EhrLabSpecimenNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
