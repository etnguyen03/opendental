CREATE TABLE `custrefentry` (
  `CustRefEntryNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNumCust` bigint(20) NOT NULL,
  `PatNumRef` bigint(20) NOT NULL,
  `DateEntry` date NOT NULL DEFAULT '0001-01-01',
  `Note` varchar(255) NOT NULL,
  PRIMARY KEY (`CustRefEntryNum`),
  KEY `PatNumCust` (`PatNumCust`),
  KEY `PatNumRef` (`PatNumRef`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
