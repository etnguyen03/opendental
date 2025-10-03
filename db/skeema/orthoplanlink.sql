CREATE TABLE `orthoplanlink` (
  `OrthoPlanLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrthoCaseNum` bigint(20) NOT NULL,
  `LinkType` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `IsActive` tinyint(4) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecUserNumEntry` bigint(20) NOT NULL,
  PRIMARY KEY (`OrthoPlanLinkNum`),
  KEY `OrthoCaseNum` (`OrthoCaseNum`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
