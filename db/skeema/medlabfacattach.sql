CREATE TABLE `medlabfacattach` (
  `MedLabFacAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MedLabNum` bigint(20) NOT NULL,
  `MedLabResultNum` bigint(20) NOT NULL,
  `MedLabFacilityNum` bigint(20) NOT NULL,
  PRIMARY KEY (`MedLabFacAttachNum`),
  KEY `MedLabNum` (`MedLabNum`),
  KEY `MedLabResultNum` (`MedLabResultNum`),
  KEY `MedLabFacilityNum` (`MedLabFacilityNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
