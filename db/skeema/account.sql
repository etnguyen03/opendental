CREATE TABLE `account` (
  `AccountNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `AcctType` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `BankNumber` varchar(255) NOT NULL,
  `Inactive` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `AccountColor` int(11) NOT NULL DEFAULT 0,
  `IsRetainedEarnings` tinyint(4) NOT NULL,
  PRIMARY KEY (`AccountNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
