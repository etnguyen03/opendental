CREATE TABLE `imagedraw` (
  `ImageDrawNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DocNum` bigint(20) NOT NULL,
  `MountNum` bigint(20) NOT NULL,
  `ColorDraw` int(11) NOT NULL,
  `ColorBack` int(11) NOT NULL,
  `DrawingSegment` text NOT NULL,
  `DrawText` varchar(255) NOT NULL,
  `FontSize` float NOT NULL,
  `DrawType` tinyint(4) NOT NULL,
  `ImageAnnotVendor` tinyint(4) NOT NULL,
  `Details` text NOT NULL,
  `PearlLayer` tinyint(4) NOT NULL,
  PRIMARY KEY (`ImageDrawNum`),
  KEY `DocNum` (`DocNum`),
  KEY `MountNum` (`MountNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
