CREATE TABLE `reqstudent` (
  `ReqStudentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ReqNeededNum` bigint(20) NOT NULL,
  `Descript` varchar(255) DEFAULT NULL,
  `SchoolCourseNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `AptNum` bigint(20) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `InstructorNum` bigint(20) NOT NULL,
  `DateCompleted` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`ReqStudentNum`),
  KEY `ReqNeededNum` (`ReqNeededNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
