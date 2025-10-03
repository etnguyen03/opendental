CREATE TABLE `codegroup` (
  `CodeGroupNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(50) NOT NULL,
  `ProcCodes` text NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `CodeGroupFixed` tinyint(4) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `ShowInAgeLimit` tinyint(4) NOT NULL,
  PRIMARY KEY (`CodeGroupNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
