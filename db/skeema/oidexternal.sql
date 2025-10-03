CREATE TABLE `oidexternal` (
  `OIDExternalNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `IDType` varchar(255) NOT NULL,
  `IDInternal` bigint(20) NOT NULL,
  `IDExternal` varchar(255) NOT NULL,
  `rootExternal` varchar(255) NOT NULL,
  PRIMARY KEY (`OIDExternalNum`),
  KEY `IDType` (`IDType`,`IDInternal`),
  KEY `rootExternal` (`rootExternal`(62),`IDExternal`(62))
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
