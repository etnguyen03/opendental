CREATE TABLE `ehramendment` (
  `EhrAmendmentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `IsAccepted` tinyint(4) NOT NULL,
  `Description` text NOT NULL,
  `Source` tinyint(4) NOT NULL,
  `SourceName` text NOT NULL,
  `FileName` varchar(255) NOT NULL,
  `RawBase64` longtext NOT NULL,
  `DateTRequest` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTAcceptDeny` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTAppend` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`EhrAmendmentNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
