CREATE TABLE `cloudaddress` (
  `CloudAddressNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `IpAddress` varchar(50) NOT NULL,
  `UserNumLastConnect` bigint(20) NOT NULL,
  `DateTimeLastConnect` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`CloudAddressNum`),
  KEY `UserNumLastConnect` (`UserNumLastConnect`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
