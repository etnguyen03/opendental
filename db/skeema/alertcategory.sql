CREATE TABLE `alertcategory` (
  `AlertCategoryNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `IsHQCategory` tinyint(4) NOT NULL,
  `InternalName` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`AlertCategoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
