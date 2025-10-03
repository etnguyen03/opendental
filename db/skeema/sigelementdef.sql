CREATE TABLE `sigelementdef` (
  `SigElementDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LightRow` tinyint(3) unsigned NOT NULL,
  `LightColor` int(11) NOT NULL,
  `SigElementType` tinyint(3) unsigned NOT NULL,
  `SigText` varchar(255) DEFAULT '',
  `Sound` mediumtext DEFAULT NULL,
  `ItemOrder` smallint(6) NOT NULL,
  PRIMARY KEY (`SigElementDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
