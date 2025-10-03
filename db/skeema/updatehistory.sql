CREATE TABLE `updatehistory` (
  `UpdateHistoryNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateTimeUpdated` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `ProgramVersion` varchar(255) NOT NULL,
  `Signature` text NOT NULL,
  PRIMARY KEY (`UpdateHistoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
