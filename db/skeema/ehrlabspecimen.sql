CREATE TABLE `ehrlabspecimen` (
  `EhrLabSpecimenNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabNum` bigint(20) NOT NULL,
  `SetIdSPM` bigint(20) NOT NULL,
  `SpecimenTypeID` varchar(255) NOT NULL,
  `SpecimenTypeText` varchar(255) NOT NULL,
  `SpecimenTypeCodeSystemName` varchar(255) NOT NULL,
  `SpecimenTypeIDAlt` varchar(255) NOT NULL,
  `SpecimenTypeTextAlt` varchar(255) NOT NULL,
  `SpecimenTypeCodeSystemNameAlt` varchar(255) NOT NULL,
  `SpecimenTypeTextOriginal` varchar(255) NOT NULL,
  `CollectionDateTimeStart` varchar(255) NOT NULL,
  `CollectionDateTimeEnd` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrLabSpecimenNum`),
  KEY `EhrLabNum` (`EhrLabNum`),
  KEY `SetIdSPM` (`SetIdSPM`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
