CREATE TABLE `alertcategorylink` (
  `AlertCategoryLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AlertCategoryNum` bigint(20) NOT NULL,
  `AlertType` tinyint(4) NOT NULL,
  PRIMARY KEY (`AlertCategoryLinkNum`),
  KEY `AlertCategoryNum` (`AlertCategoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
