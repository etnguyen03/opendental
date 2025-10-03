CREATE TABLE `claimcondcodelog` (
  `ClaimCondCodeLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimNum` bigint(20) NOT NULL,
  `Code0` varchar(2) DEFAULT NULL,
  `Code1` varchar(2) DEFAULT NULL,
  `Code2` varchar(2) DEFAULT NULL,
  `Code3` varchar(2) DEFAULT NULL,
  `Code4` varchar(2) DEFAULT NULL,
  `Code5` varchar(2) DEFAULT NULL,
  `Code6` varchar(2) DEFAULT NULL,
  `Code7` varchar(2) DEFAULT NULL,
  `Code8` varchar(2) DEFAULT NULL,
  `Code9` varchar(2) DEFAULT NULL,
  `Code10` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`ClaimCondCodeLogNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
