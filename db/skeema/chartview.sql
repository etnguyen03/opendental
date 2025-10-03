CREATE TABLE `chartview` (
  `ChartViewNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `ProcStatuses` tinyint(4) NOT NULL,
  `ObjectTypes` smallint(6) NOT NULL,
  `ShowProcNotes` tinyint(4) NOT NULL,
  `IsAudit` tinyint(4) NOT NULL,
  `SelectedTeethOnly` tinyint(4) NOT NULL,
  `OrionStatusFlags` int(11) NOT NULL,
  `DatesShowing` tinyint(4) NOT NULL,
  `IsTpCharting` tinyint(4) NOT NULL,
  PRIMARY KEY (`ChartViewNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
