CREATE TABLE `cert` (
  `CertNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `WikiPageLink` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `CertCategoryNum` bigint(20) NOT NULL,
  PRIMARY KEY (`CertNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
