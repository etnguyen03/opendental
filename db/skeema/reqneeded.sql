CREATE TABLE `reqneeded` (
  `ReqNeededNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Descript` varchar(255) DEFAULT NULL,
  `SchoolCourseNum` bigint(20) NOT NULL,
  `SchoolClassNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ReqNeededNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
