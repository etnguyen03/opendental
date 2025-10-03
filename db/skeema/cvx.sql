CREATE TABLE `cvx` (
  `CvxNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CvxCode` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `IsActive` varchar(255) NOT NULL,
  PRIMARY KEY (`CvxNum`),
  KEY `CvxCode` (`CvxCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
