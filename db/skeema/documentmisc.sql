CREATE TABLE `documentmisc` (
  `DocMiscNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateCreated` date NOT NULL DEFAULT '0001-01-01',
  `FileName` varchar(255) NOT NULL,
  `DocMiscType` tinyint(4) NOT NULL,
  `RawBase64` longtext NOT NULL,
  PRIMARY KEY (`DocMiscNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
