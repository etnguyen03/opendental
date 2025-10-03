CREATE TABLE `cdspermission` (
  `CDSPermissionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `SetupCDS` tinyint(4) NOT NULL,
  `ShowCDS` tinyint(4) NOT NULL,
  `ShowInfobutton` tinyint(4) NOT NULL,
  `EditBibliography` tinyint(4) NOT NULL,
  `ProblemCDS` tinyint(4) NOT NULL,
  `MedicationCDS` tinyint(4) NOT NULL,
  `AllergyCDS` tinyint(4) NOT NULL,
  `DemographicCDS` tinyint(4) NOT NULL,
  `LabTestCDS` tinyint(4) NOT NULL,
  `VitalCDS` tinyint(4) NOT NULL,
  PRIMARY KEY (`CDSPermissionNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
