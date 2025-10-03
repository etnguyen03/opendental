CREATE TABLE `requiredfield` (
  `RequiredFieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FieldType` tinyint(4) NOT NULL,
  `FieldName` varchar(50) NOT NULL,
  PRIMARY KEY (`RequiredFieldNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
