CREATE TABLE `procbuttonquick` (
  `ProcButtonQuickNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `CodeValue` varchar(255) NOT NULL,
  `Surf` varchar(255) NOT NULL,
  `YPos` int(11) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `IsLabel` tinyint(4) NOT NULL,
  PRIMARY KEY (`ProcButtonQuickNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
