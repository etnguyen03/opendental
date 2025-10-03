CREATE TABLE `custreference` (
  `CustReferenceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateMostRecent` date NOT NULL DEFAULT '0001-01-01',
  `Note` varchar(255) NOT NULL,
  `IsBadRef` tinyint(4) NOT NULL,
  PRIMARY KEY (`CustReferenceNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
