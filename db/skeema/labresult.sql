CREATE TABLE `labresult` (
  `LabResultNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LabPanelNum` bigint(20) NOT NULL,
  `DateTimeTest` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `TestName` varchar(255) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `TestID` varchar(255) NOT NULL,
  `ObsValue` varchar(255) NOT NULL,
  `ObsUnits` varchar(255) NOT NULL,
  `ObsRange` varchar(255) NOT NULL,
  `AbnormalFlag` tinyint(4) NOT NULL,
  PRIMARY KEY (`LabResultNum`),
  KEY `LabPanelNum` (`LabPanelNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
