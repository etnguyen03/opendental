CREATE TABLE `hcpcs` (
  `HcpcsNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HcpcsCode` varchar(255) NOT NULL,
  `DescriptionShort` varchar(255) NOT NULL,
  PRIMARY KEY (`HcpcsNum`),
  KEY `HcpcsCode` (`HcpcsCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
