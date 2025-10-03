CREATE TABLE `pearlrequest` (
  `PearlRequestNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RequestId` varchar(255) NOT NULL,
  `DocNum` bigint(20) NOT NULL,
  `RequestStatus` tinyint(4) NOT NULL,
  `DateTSent` date NOT NULL DEFAULT '0001-01-01',
  `DateTChecked` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`PearlRequestNum`),
  KEY `RequestStatus` (`RequestStatus`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
