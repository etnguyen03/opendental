CREATE TABLE `computer` (
  `ComputerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CompName` varchar(100) DEFAULT '',
  `LastHeartBeat` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`ComputerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
