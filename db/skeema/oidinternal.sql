CREATE TABLE `oidinternal` (
  `OIDInternalNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `IDType` varchar(255) NOT NULL,
  `IDRoot` varchar(255) NOT NULL,
  PRIMARY KEY (`OIDInternalNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
