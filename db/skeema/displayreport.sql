CREATE TABLE `displayreport` (
  `DisplayReportNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `InternalName` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Category` tinyint(4) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `IsVisibleInSubMenu` tinyint(4) NOT NULL,
  PRIMARY KEY (`DisplayReportNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
