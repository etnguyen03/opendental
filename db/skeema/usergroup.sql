CREATE TABLE `usergroup` (
  `UserGroupNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `UserGroupNumCEMT` bigint(20) NOT NULL,
  PRIMARY KEY (`UserGroupNum`),
  KEY `UserGroupNumCEMT` (`UserGroupNumCEMT`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
