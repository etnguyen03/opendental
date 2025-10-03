CREATE TABLE `mobiledatabyte` (
  `MobileDataByteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RawBase64Data` mediumtext NOT NULL,
  `RawBase64Code` mediumtext NOT NULL,
  `RawBase64Tag` mediumtext NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `ActionType` tinyint(4) NOT NULL,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTimeExpires` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`MobileDataByteNum`),
  KEY `PatNum` (`PatNum`),
  KEY `RawBase64Code` (`RawBase64Code`(16))
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
