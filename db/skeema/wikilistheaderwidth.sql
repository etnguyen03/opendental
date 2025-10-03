CREATE TABLE `wikilistheaderwidth` (
  `WikiListHeaderWidthNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ListName` varchar(255) NOT NULL,
  `ColName` varchar(255) NOT NULL,
  `ColWidth` int(11) NOT NULL,
  `PickList` text NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`WikiListHeaderWidthNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
