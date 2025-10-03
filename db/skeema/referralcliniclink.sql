CREATE TABLE `referralcliniclink` (
  `ReferralClinicLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ReferralNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ReferralClinicLinkNum`),
  KEY `ReferralNum` (`ReferralNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
