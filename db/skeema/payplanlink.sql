CREATE TABLE `payplanlink` (
  `PayPlanLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PayPlanNum` bigint(20) NOT NULL,
  `LinkType` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `AmountOverride` double NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`PayPlanLinkNum`),
  KEY `PayPlanNum` (`PayPlanNum`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
