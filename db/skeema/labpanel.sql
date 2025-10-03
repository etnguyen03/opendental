CREATE TABLE `labpanel` (
  `LabPanelNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `RawMessage` text NOT NULL,
  `LabNameAddress` varchar(255) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `SpecimenCondition` varchar(255) NOT NULL,
  `SpecimenSource` varchar(255) NOT NULL,
  `ServiceId` varchar(255) NOT NULL,
  `ServiceName` varchar(255) NOT NULL,
  `MedicalOrderNum` bigint(20) NOT NULL,
  PRIMARY KEY (`LabPanelNum`),
  KEY `PatNum` (`PatNum`),
  KEY `MedicalOrderNum` (`MedicalOrderNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
