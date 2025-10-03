CREATE TABLE `claimform` (
  `ClaimFormNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(50) DEFAULT '',
  `IsHidden` tinyint(1) unsigned NOT NULL DEFAULT 0,
  `FontName` varchar(255) DEFAULT '',
  `FontSize` float unsigned NOT NULL DEFAULT 0,
  `UniqueID` varchar(255) DEFAULT '',
  `PrintImages` tinyint(1) unsigned NOT NULL DEFAULT 0,
  `OffsetX` smallint(5) NOT NULL DEFAULT 0,
  `OffsetY` smallint(5) NOT NULL DEFAULT 0,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  PRIMARY KEY (`ClaimFormNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
