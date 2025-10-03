CREATE TABLE `electid` (
  `ElectIDNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PayorID` varchar(255) DEFAULT '',
  `CarrierName` varchar(255) DEFAULT '',
  `IsMedicaid` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `ProviderTypes` varchar(255) DEFAULT '',
  `Comments` text DEFAULT NULL,
  `CommBridge` tinyint(4) NOT NULL,
  `Attributes` varchar(255) NOT NULL,
  PRIMARY KEY (`ElectIDNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
