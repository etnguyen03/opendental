CREATE TABLE `toothinitial` (
  `ToothInitialNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ToothNum` varchar(2) DEFAULT '',
  `InitialType` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `Movement` float NOT NULL DEFAULT 0,
  `DrawingSegment` text DEFAULT NULL,
  `ColorDraw` int(11) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `DrawText` varchar(255) NOT NULL,
  PRIMARY KEY (`ToothInitialNum`),
  KEY `PatNum` (`PatNum`),
  KEY `SecDateTEntry` (`SecDateTEntry`),
  KEY `SecDateTEdit` (`SecDateTEdit`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
