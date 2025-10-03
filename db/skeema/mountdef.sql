CREATE TABLE `mountdef` (
  `MountDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `ItemOrder` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  `ColorBack` int(11) NOT NULL,
  `ColorFore` int(11) NOT NULL,
  `ColorTextBack` int(11) NOT NULL,
  `ScaleValue` varchar(255) NOT NULL,
  `DefaultCat` bigint(20) NOT NULL,
  `FlipOnAcquire` tinyint(4) NOT NULL,
  `AdjModeAfterSeries` tinyint(4) NOT NULL,
  PRIMARY KEY (`MountDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
