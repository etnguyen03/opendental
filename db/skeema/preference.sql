CREATE TABLE `preference` (
  `PrefName` varchar(255) NOT NULL DEFAULT '',
  `ValueString` text NOT NULL,
  `PrefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Comments` text DEFAULT NULL,
  PRIMARY KEY (`PrefNum`),
  KEY `PrefName` (`PrefName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
