CREATE TABLE `orthocharttab` (
  `OrthoChartTabNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TabName` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`OrthoChartTabNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
