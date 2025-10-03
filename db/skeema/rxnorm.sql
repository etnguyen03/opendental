CREATE TABLE `rxnorm` (
  `RxNormNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RxCui` varchar(255) NOT NULL,
  `MmslCode` varchar(255) NOT NULL,
  `Description` text NOT NULL,
  PRIMARY KEY (`RxNormNum`),
  KEY `RxCui` (`RxCui`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
