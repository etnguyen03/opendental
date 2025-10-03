CREATE TABLE `terminalactive` (
  `TerminalActiveNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComputerName` varchar(255) DEFAULT '',
  `TerminalStatus` tinyint(3) unsigned NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `SessionId` int(11) NOT NULL,
  `ProcessId` int(11) NOT NULL,
  `SessionName` varchar(255) NOT NULL,
  PRIMARY KEY (`TerminalActiveNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
