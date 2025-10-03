CREATE TABLE `eformdef` (
  `EFormDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FormType` tinyint(4) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `DateTCreated` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `IsInternalHidden` tinyint(4) NOT NULL,
  `MaxWidth` int(11) NOT NULL,
  `RevID` int(11) NOT NULL,
  `ShowLabelsBold` tinyint(4) NOT NULL,
  `SpaceBelowEachField` int(11) NOT NULL,
  `SpaceToRightEachField` int(11) NOT NULL,
  `SaveImageCategory` bigint(20) NOT NULL,
  PRIMARY KEY (`EFormDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
