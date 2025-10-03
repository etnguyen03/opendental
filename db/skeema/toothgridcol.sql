CREATE TABLE `toothgridcol` (
  `ToothGridColNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SheetFieldNum` bigint(20) NOT NULL,
  `NameItem` varchar(255) NOT NULL,
  `CellType` tinyint(4) NOT NULL,
  `ItemOrder` smallint(6) NOT NULL,
  `ColumnWidth` smallint(6) NOT NULL,
  `CodeNum` bigint(20) NOT NULL,
  `ProcStatus` tinyint(4) NOT NULL,
  PRIMARY KEY (`ToothGridColNum`),
  KEY `SheetFieldNum` (`SheetFieldNum`),
  KEY `CodeNum` (`CodeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
