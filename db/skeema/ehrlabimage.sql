CREATE TABLE `ehrlabimage` (
  `EhrLabImageNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabNum` bigint(20) NOT NULL,
  `DocNum` bigint(20) NOT NULL,
  PRIMARY KEY (`EhrLabImageNum`),
  KEY `EhrLabNum` (`EhrLabNum`),
  KEY `DocNum` (`DocNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
