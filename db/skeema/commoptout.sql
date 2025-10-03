CREATE TABLE `commoptout` (
  `CommOptOutNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `OptOutSms` int(11) NOT NULL,
  `OptOutEmail` int(11) NOT NULL,
  PRIMARY KEY (`CommOptOutNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
