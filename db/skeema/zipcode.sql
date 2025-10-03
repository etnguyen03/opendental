CREATE TABLE `zipcode` (
  `ZipCodeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ZipCodeDigits` varchar(20) DEFAULT '',
  `City` varchar(100) DEFAULT '',
  `State` varchar(20) DEFAULT '',
  `IsFrequent` tinyint(1) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`ZipCodeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
