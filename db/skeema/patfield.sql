CREATE TABLE `patfield` (
  `PatFieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `FieldName` varchar(255) DEFAULT '',
  `FieldValue` text DEFAULT NULL,
  `SecUserNumEntry` bigint(20) NOT NULL,
  `SecDateEntry` date NOT NULL DEFAULT '0001-01-01',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`PatFieldNum`),
  KEY `PatNum` (`PatNum`),
  KEY `SecUserNumEntry` (`SecUserNumEntry`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
