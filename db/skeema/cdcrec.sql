CREATE TABLE `cdcrec` (
  `CdcrecNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CdcrecCode` varchar(255) NOT NULL,
  `HeirarchicalCode` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`CdcrecNum`),
  KEY `CdcrecCode` (`CdcrecCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
