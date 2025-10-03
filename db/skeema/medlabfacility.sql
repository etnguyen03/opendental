CREATE TABLE `medlabfacility` (
  `MedLabFacilityNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FacilityName` varchar(255) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `City` varchar(255) NOT NULL,
  `State` varchar(255) NOT NULL,
  `Zip` varchar(255) NOT NULL,
  `Phone` varchar(255) NOT NULL,
  `DirectorTitle` varchar(255) NOT NULL,
  `DirectorLName` varchar(255) NOT NULL,
  `DirectorFName` varchar(255) NOT NULL,
  PRIMARY KEY (`MedLabFacilityNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
