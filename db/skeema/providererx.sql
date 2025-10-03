CREATE TABLE `providererx` (
  `ProviderErxNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `NationalProviderID` varchar(255) NOT NULL,
  `IsEnabled` tinyint(4) NOT NULL,
  `IsIdentifyProofed` tinyint(4) NOT NULL,
  `IsSentToHq` tinyint(4) NOT NULL,
  `IsEpcs` tinyint(4) NOT NULL,
  `ErxType` tinyint(4) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `AccountId` varchar(25) NOT NULL,
  `RegistrationKeyNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ProviderErxNum`),
  KEY `PatNum` (`PatNum`),
  KEY `RegistrationKeyNum` (`RegistrationKeyNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
