CREATE TABLE `ucum` (
  `UcumNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UcumCode` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `IsInUse` tinyint(4) NOT NULL,
  PRIMARY KEY (`UcumNum`),
  KEY `UcumCode` (`UcumCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
