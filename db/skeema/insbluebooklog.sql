CREATE TABLE `insbluebooklog` (
  `InsBlueBookLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimProcNum` bigint(20) NOT NULL,
  `AllowedFee` double NOT NULL,
  `DateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Description` text NOT NULL,
  PRIMARY KEY (`InsBlueBookLogNum`),
  KEY `ClaimProcNum` (`ClaimProcNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
