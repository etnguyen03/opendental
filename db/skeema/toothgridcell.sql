CREATE TABLE `toothgridcell` (
  `ToothGridCellNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SheetFieldNum` bigint(20) NOT NULL,
  `ToothGridColNum` bigint(20) NOT NULL,
  `ValueEntered` varchar(255) NOT NULL,
  `ToothNum` varchar(10) NOT NULL,
  PRIMARY KEY (`ToothGridCellNum`),
  KEY `SheetFieldNum` (`SheetFieldNum`),
  KEY `ToothGridColNum` (`ToothGridColNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
