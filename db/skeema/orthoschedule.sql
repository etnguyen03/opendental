CREATE TABLE `orthoschedule` (
  `OrthoScheduleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `BandingDateOverride` date NOT NULL DEFAULT '0001-01-01',
  `DebondDateOverride` date NOT NULL DEFAULT '0001-01-01',
  `BandingAmount` double NOT NULL,
  `VisitAmount` double NOT NULL,
  `DebondAmount` double NOT NULL,
  `IsActive` tinyint(4) NOT NULL,
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`OrthoScheduleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
