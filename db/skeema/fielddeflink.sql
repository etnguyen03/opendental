CREATE TABLE `fielddeflink` (
  `FieldDefLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FieldDefNum` bigint(20) NOT NULL,
  `FieldDefType` tinyint(4) NOT NULL,
  `FieldLocation` tinyint(4) NOT NULL,
  PRIMARY KEY (`FieldDefLinkNum`),
  KEY `FieldDefNum` (`FieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
