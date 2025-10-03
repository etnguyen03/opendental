CREATE TABLE `conngroupattach` (
  `ConnGroupAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ConnectionGroupNum` bigint(20) NOT NULL,
  `CentralConnectionNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ConnGroupAttachNum`),
  KEY `ConnectionGroupNum` (`ConnectionGroupNum`),
  KEY `CentralConnectionNum` (`CentralConnectionNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
