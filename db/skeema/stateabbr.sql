CREATE TABLE `stateabbr` (
  `StateAbbrNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(50) NOT NULL,
  `Abbr` varchar(50) NOT NULL,
  `MedicaidIDLength` int(11) NOT NULL,
  PRIMARY KEY (`StateAbbrNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
