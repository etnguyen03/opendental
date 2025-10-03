CREATE TABLE `apptfielddef` (
  `ApptFieldDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FieldName` varchar(255) NOT NULL,
  `FieldType` tinyint(4) NOT NULL,
  `PickList` text NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  PRIMARY KEY (`ApptFieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
