CREATE TABLE `apptfield` (
  `ApptFieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AptNum` bigint(20) NOT NULL,
  `FieldName` varchar(255) NOT NULL,
  `FieldValue` text NOT NULL,
  PRIMARY KEY (`ApptFieldNum`),
  KEY `AptNum` (`AptNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
