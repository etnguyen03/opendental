CREATE TABLE `eform` (
  `EFormNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FormType` tinyint(4) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `DateTimeShown` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Description` varchar(255) NOT NULL,
  `DateTEdited` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `MaxWidth` int(11) NOT NULL,
  `EFormDefNum` bigint(20) NOT NULL,
  `Status` tinyint(4) NOT NULL,
  `RevID` int(11) NOT NULL,
  `ShowLabelsBold` tinyint(4) NOT NULL,
  `SpaceBelowEachField` int(11) NOT NULL,
  `SpaceToRightEachField` int(11) NOT NULL,
  `SaveImageCategory` bigint(20) NOT NULL,
  PRIMARY KEY (`EFormNum`),
  KEY `PatNum` (`PatNum`),
  KEY `EFormDefNum` (`EFormDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
