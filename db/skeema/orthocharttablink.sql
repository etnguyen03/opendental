CREATE TABLE `orthocharttablink` (
  `OrthoChartTabLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ItemOrder` int(11) NOT NULL,
  `OrthoChartTabNum` bigint(20) NOT NULL,
  `DisplayFieldNum` bigint(20) NOT NULL,
  `ColumnWidthOverride` int(11) NOT NULL,
  PRIMARY KEY (`OrthoChartTabLinkNum`),
  KEY `OrthoChartTabNum` (`OrthoChartTabNum`),
  KEY `DisplayFieldNum` (`DisplayFieldNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
