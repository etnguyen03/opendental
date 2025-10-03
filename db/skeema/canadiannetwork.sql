CREATE TABLE `canadiannetwork` (
  `CanadianNetworkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Abbrev` varchar(20) DEFAULT '',
  `Descript` varchar(255) DEFAULT '',
  `CanadianTransactionPrefix` varchar(255) NOT NULL,
  `CanadianIsRprHandler` tinyint(4) NOT NULL,
  PRIMARY KEY (`CanadianNetworkNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
