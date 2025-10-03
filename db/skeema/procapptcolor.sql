CREATE TABLE `procapptcolor` (
  `ProcApptColorNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CodeRange` varchar(255) NOT NULL,
  `ColorText` int(11) NOT NULL,
  `ShowPreviousDate` tinyint(4) NOT NULL,
  PRIMARY KEY (`ProcApptColorNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
