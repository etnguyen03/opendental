CREATE TABLE `utm` (
  `UtmNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CampaignName` varchar(500) NOT NULL,
  `MediumInfo` varchar(500) NOT NULL,
  `SourceInfo` varchar(500) NOT NULL,
  PRIMARY KEY (`UtmNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
