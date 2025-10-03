CREATE TABLE `orionproc` (
  `OrionProcNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProcNum` bigint(20) NOT NULL,
  `DPC` tinyint(4) NOT NULL,
  `DateScheduleBy` date NOT NULL DEFAULT '0001-01-01',
  `DateStopClock` date NOT NULL DEFAULT '0001-01-01',
  `Status2` int(11) NOT NULL,
  `IsOnCall` tinyint(4) NOT NULL,
  `IsEffectiveComm` tinyint(4) NOT NULL,
  `IsRepair` tinyint(4) NOT NULL,
  `DPCpost` tinyint(4) NOT NULL,
  PRIMARY KEY (`OrionProcNum`),
  KEY `ProcNum` (`ProcNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
