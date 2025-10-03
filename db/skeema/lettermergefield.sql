CREATE TABLE `lettermergefield` (
  `FieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LetterMergeNum` bigint(20) NOT NULL,
  `FieldName` varchar(255) DEFAULT '',
  PRIMARY KEY (`FieldNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
