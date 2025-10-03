CREATE TABLE `emailsecure` (
  `EmailSecureNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `EmailMessageNum` bigint(20) NOT NULL,
  `EmailChainFK` bigint(20) NOT NULL,
  `EmailFK` bigint(20) NOT NULL,
  `DateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`EmailSecureNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `PatNum` (`PatNum`),
  KEY `EmailMessageNum` (`EmailMessageNum`),
  KEY `EmailChainFK` (`EmailChainFK`),
  KEY `EmailFK` (`EmailFK`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
