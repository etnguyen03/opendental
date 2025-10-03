CREATE TABLE `displayfield` (
  `DisplayFieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `InternalName` varchar(255) DEFAULT NULL,
  `ItemOrder` int(11) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `ColumnWidth` int(11) NOT NULL,
  `Category` int(11) NOT NULL DEFAULT 0,
  `ChartViewNum` bigint(20) NOT NULL,
  `PickList` text NOT NULL,
  `DescriptionOverride` varchar(255) NOT NULL,
  PRIMARY KEY (`DisplayFieldNum`),
  KEY `ChartViewNum` (`ChartViewNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
