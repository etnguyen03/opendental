CREATE TABLE `icd9` (
  `ICD9Num` bigint(20) NOT NULL AUTO_INCREMENT,
  `ICD9Code` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`ICD9Num`),
  KEY `ICD9Code` (`ICD9Code`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
