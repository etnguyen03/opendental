CREATE TABLE `deflink` (
  `DefLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DefNum` bigint(20) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `LinkType` tinyint(4) NOT NULL,
  PRIMARY KEY (`DefLinkNum`),
  KEY `DefNum` (`DefNum`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
