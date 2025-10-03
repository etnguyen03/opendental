CREATE TABLE `toothgriddef` (
  `ToothGridDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `NameInternal` varchar(255) DEFAULT NULL,
  `NameShowing` varchar(255) DEFAULT NULL,
  `CellType` tinyint(4) NOT NULL,
  `ItemOrder` smallint(6) NOT NULL,
  `ColumnWidth` smallint(6) NOT NULL,
  `CodeNum` bigint(20) NOT NULL,
  `ProcStatus` tinyint(4) NOT NULL,
  `SheetFieldDefNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ToothGridDefNum`),
  KEY `CodeNum` (`CodeNum`),
  KEY `SheetFieldDefNum` (`SheetFieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
