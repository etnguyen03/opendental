CREATE TABLE `languageforeign` (
  `LanguageForeignNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClassType` text DEFAULT NULL,
  `English` text DEFAULT NULL,
  `Culture` varchar(255) DEFAULT '',
  `Translation` text DEFAULT NULL,
  `Comments` text DEFAULT NULL,
  PRIMARY KEY (`LanguageForeignNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
