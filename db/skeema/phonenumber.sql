CREATE TABLE `phonenumber` (
  `PhoneNumberNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `PhoneNumberVal` varchar(255) DEFAULT NULL,
  `PhoneNumberDigits` varchar(30) NOT NULL,
  `PhoneType` tinyint(4) NOT NULL,
  PRIMARY KEY (`PhoneNumberNum`),
  KEY `PatNum` (`PatNum`),
  KEY `PhoneNumberVal` (`PhoneNumberVal`),
  KEY `PatPhoneDigits` (`PatNum`,`PhoneNumberDigits`),
  KEY `PhoneNumberDigits` (`PhoneNumberDigits`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
