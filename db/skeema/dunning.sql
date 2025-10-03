CREATE TABLE `dunning` (
  `DunningNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DunMessage` text DEFAULT NULL,
  `BillingType` bigint(20) NOT NULL,
  `AgeAccount` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `InsIsPending` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `MessageBold` text DEFAULT NULL,
  `EmailSubject` varchar(255) NOT NULL,
  `EmailBody` mediumtext NOT NULL,
  `DaysInAdvance` int(11) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `IsSuperFamily` tinyint(4) NOT NULL,
  PRIMARY KEY (`DunningNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
