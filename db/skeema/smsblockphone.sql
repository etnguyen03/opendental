CREATE TABLE `smsblockphone` (
  `SmsBlockPhoneNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `BlockWirelessNumber` varchar(255) NOT NULL,
  PRIMARY KEY (`SmsBlockPhoneNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
