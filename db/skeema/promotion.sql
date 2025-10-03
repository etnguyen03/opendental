CREATE TABLE `promotion` (
  `PromotionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PromotionName` varchar(255) NOT NULL,
  `DateTimeCreated` date NOT NULL DEFAULT '0001-01-01',
  `ClinicNum` bigint(20) NOT NULL,
  `TypePromotion` tinyint(4) NOT NULL,
  PRIMARY KEY (`PromotionNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
