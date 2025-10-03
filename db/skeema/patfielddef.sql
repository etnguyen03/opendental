CREATE TABLE `patfielddef` (
  `PatFieldDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FieldName` varchar(255) DEFAULT '',
  `FieldType` tinyint(4) NOT NULL,
  `PickList` text NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`PatFieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
