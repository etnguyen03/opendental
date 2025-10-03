CREATE TABLE `userodpref` (
  `UserOdPrefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `Fkey` bigint(20) NOT NULL,
  `FkeyType` tinyint(4) NOT NULL,
  `ValueString` text NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  PRIMARY KEY (`UserOdPrefNum`),
  KEY `UserNum` (`UserNum`),
  KEY `Fkey` (`Fkey`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
