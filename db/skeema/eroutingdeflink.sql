CREATE TABLE `eroutingdeflink` (
  `ERoutingDefLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ERoutingDefNum` bigint(20) NOT NULL,
  `Fkey` bigint(20) NOT NULL,
  `ERoutingType` tinyint(4) NOT NULL,
  PRIMARY KEY (`ERoutingDefLinkNum`),
  KEY `ERoutingDefNum` (`ERoutingDefNum`),
  KEY `Fkey` (`Fkey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
