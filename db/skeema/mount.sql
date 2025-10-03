CREATE TABLE `mount` (
  `MountNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DocCategory` bigint(20) NOT NULL,
  `DateCreated` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Description` varchar(255) NOT NULL,
  `Note` text NOT NULL,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  `ColorBack` int(11) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `ColorFore` int(11) NOT NULL,
  `ColorTextBack` int(11) NOT NULL,
  `FlipOnAcquire` tinyint(4) NOT NULL,
  `AdjModeAfterSeries` tinyint(4) NOT NULL,
  PRIMARY KEY (`MountNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
