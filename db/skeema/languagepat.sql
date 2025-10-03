CREATE TABLE `languagepat` (
  `LanguagePatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PrefName` varchar(255) NOT NULL,
  `Language` varchar(255) NOT NULL,
  `Translation` text NOT NULL,
  `EFormFieldDefNum` bigint(20) NOT NULL,
  PRIMARY KEY (`LanguagePatNum`),
  KEY `PrefName` (`PrefName`),
  KEY `EFormFieldDefNum` (`EFormFieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
