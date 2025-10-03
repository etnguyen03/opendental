CREATE TABLE `webschedcarrierrule` (
  `WebSchedCarrierRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `CarrierName` varchar(255) NOT NULL,
  `DisplayName` varchar(255) NOT NULL,
  `Message` text NOT NULL,
  `Rule` tinyint(4) NOT NULL,
  PRIMARY KEY (`WebSchedCarrierRuleNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
