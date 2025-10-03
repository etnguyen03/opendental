CREATE TABLE `eclipboardimagecapture` (
  `EClipboardImageCaptureNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DefNum` bigint(20) NOT NULL,
  `IsSelfPortrait` tinyint(4) NOT NULL,
  `DateTimeUpserted` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DocNum` bigint(20) NOT NULL,
  `OcrCaptureType` tinyint(4) NOT NULL DEFAULT 0,
  PRIMARY KEY (`EClipboardImageCaptureNum`),
  KEY `PatNum` (`PatNum`),
  KEY `DefNum` (`DefNum`),
  KEY `DocNum` (`DocNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
