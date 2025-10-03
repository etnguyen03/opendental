CREATE TABLE `schoolclass` (
  `SchoolClassNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `GradYear` int(11) NOT NULL,
  `Descript` varchar(255) DEFAULT '',
  PRIMARY KEY (`SchoolClassNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
