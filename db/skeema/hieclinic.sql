CREATE TABLE `hieclinic` (
  `HieClinicNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `SupportedCarrierFlags` tinyint(4) NOT NULL,
  `PathExportCCD` varchar(255) NOT NULL,
  `TimeOfDayExportCCD` bigint(20) NOT NULL,
  `IsEnabled` tinyint(4) NOT NULL,
  PRIMARY KEY (`HieClinicNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `TimeOfDayExportCCD` (`TimeOfDayExportCCD`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
