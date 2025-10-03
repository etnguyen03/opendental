CREATE TABLE `mountitemdef` (
  `MountItemDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MountDefNum` bigint(20) NOT NULL,
  `Xpos` int(11) NOT NULL,
  `Ypos` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `RotateOnAcquire` int(11) NOT NULL,
  `ToothNumbers` varchar(255) NOT NULL,
  `TextShowing` text NOT NULL,
  `FontSize` float NOT NULL,
  PRIMARY KEY (`MountItemDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
